using TypographyContracts.StoragesContracts;
using TypographyDatabaseImplement.Models;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TypographyDatabaseImplement.Implements {
    public class WarehouseStorage : IWarehouseStorage {
        public List<WarehouseViewModel> GetFullList() {
            using var context = new TypographyDatabase();
            return context.Warehouses
                .Include(rec => rec.WarehouseComponents)
                .ThenInclude(rec => rec.Component)
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model) {
            if (model == null) {
                return null;
            }

            using var context = new TypographyDatabase();
            return context.Warehouses
                .Include(rec => rec.WarehouseComponents)
                .ThenInclude(rec => rec.Component)
                .Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model) {
            if (model == null) {
                return null;
            }

            using var context = new TypographyDatabase();
            var warehouse = context.Warehouses
                .Include(rec => rec.WarehouseComponents)
                .ThenInclude(rec => rec.Component)
                .FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName || rec.Id == model.Id);

            return warehouse != null ? CreateModel(warehouse) : null;
        }

        public void Insert(WarehouseBindingModel model) {
            using var context = new TypographyDatabase();
            using var transaction = context.Database.BeginTransaction();

            try {
                CreateModel(model, new Warehouse(), context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(WarehouseBindingModel model) {
            using var context = new TypographyDatabase();
            using var transaction = context.Database.BeginTransaction();

            try {
                var element = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
                
                if (element == null) {
                    throw new Exception("Склад не найден");
                }

                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch {
                transaction.Rollback();
                throw;
            }
        }

        public void Delete(WarehouseBindingModel model) {
            using var context = new TypographyDatabase();
            Warehouse warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

            if (warehouse == null) {
                throw new Exception("Склад не найден");
            }

            context.Warehouses.Remove(warehouse);
            context.SaveChanges();
        }

        private static Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse, TypographyDatabase context) {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.WarehouseManagerFullName = model.WarehouseManagerFullName;
            warehouse.DateCreate = model.DateCreate;

            if (model.Id.HasValue) {
                var warehouseComponents = context.WarehouseComponents.Where(rec => rec.WarehouseId == model.Id.Value).ToList();
                
                context.WarehouseComponents.RemoveRange(warehouseComponents.Where(rec => !model.WarehouseComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                
                foreach (var updateComponent in warehouseComponents) {
                    updateComponent.Count = model.WarehouseComponents[updateComponent.ComponentId].Item2;
                    model.WarehouseComponents.Remove(updateComponent.ComponentId);
                }

                context.SaveChanges();
            }

            foreach (var pc in model.WarehouseComponents) {
                context.WarehouseComponents.Add(new WarehouseComponent {
                    WarehouseId = warehouse.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });

                context.SaveChanges();
            }
            return warehouse;
        }

        private static WarehouseViewModel CreateModel(Warehouse warehouse) {
            return new WarehouseViewModel {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                WarehouseManagerFullName = warehouse.WarehouseManagerFullName,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouse.WarehouseComponents.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
            };
        }

        public bool CheckRemove(Dictionary<int, (string, int)> components, int printedsCount) {
            using var context = new TypographyDatabase();
            using var transaction = context.Database.BeginTransaction();
            
            try {
                foreach (KeyValuePair<int, (string, int)> warehouseComponent in components) {
                    int requiredCount = warehouseComponent.Value.Item2 * printedsCount;
                    IEnumerable<WarehouseComponent> warehouseComponents = context.WarehouseComponents.Where(warehouse => warehouse.ComponentId == warehouseComponent.Key);
                    
                    foreach (WarehouseComponent component in warehouseComponents) {
                        if (component.Count <= requiredCount) {
                            requiredCount -= component.Count;
                            context.WarehouseComponents.Remove(component);
                        }
                        else {
                            component.Count -= requiredCount;
                            requiredCount = 0;
                            break;
                        }
                    }
                    
                    if (requiredCount != 0) {
                        throw new Exception("На складе недостаточно материалов");
                    }
                }
                
                context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch {
                transaction.Rollback();
                throw;
            }
        }
    }
}