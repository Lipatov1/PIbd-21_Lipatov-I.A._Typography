﻿using TypographyContracts.StoragesContracts;
using TypographyDatabaseImplement.Models;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TypographyDatabaseImplement.Implements {
    public class WarehouseStorage : IWarehouseStorage {
        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse, TypographyDatabase context) {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.WarehouseManagerFullName = model.WarehouseManagerFullName;

            if (warehouse.Id == 0) {
                warehouse.DateCreate = DateTime.Now;
                context.Warehouses.Add(warehouse);
                context.SaveChanges();
            }

            if (model.Id.HasValue) {
                List<WarehouseComponent> WarehouseComponents = context.WarehouseComponents
                    .Where(rec => rec.WarehouseId == model.Id.Value)
                    .ToList();

                context.WarehouseComponents.RemoveRange(WarehouseComponents
                        .Where(rec => !model.WarehouseComponents.ContainsKey(rec.ComponentId))
                        .ToList());
                context.SaveChanges();

                foreach (WarehouseComponent updateComponent in WarehouseComponents) {
                    updateComponent.Count = model.WarehouseComponents[updateComponent.ComponentId].Item2;
                    model.WarehouseComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }


            foreach (KeyValuePair<int, (string, int)> warehouseComponent in model.WarehouseComponents) {
                context.WarehouseComponents.Add(new WarehouseComponent {
                    WarehouseId = warehouse.Id,
                    ComponentId = warehouseComponent.Key,
                    Count = warehouseComponent.Value.Item2
                });
                context.SaveChanges();
            }

            return warehouse;
        }

        public List<WarehouseViewModel> GetFullList() {
            using (TypographyDatabase context = new TypographyDatabase()) {
                return context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .ToList()
                    .Select(rec => new WarehouseViewModel {
                        Id = rec.Id,
                        WarehouseName = rec.WarehouseName,
                        WarehouseManagerFullName = rec.WarehouseManagerFullName,
                        DateCreate = rec.DateCreate,
                        WarehouseComponents = rec.WarehouseComponents
                            .ToDictionary(recWC => recWC.ComponentId,
                            recWC => (recWC.Component?.ComponentName,
                            recWC.Count))
                    })
                    .ToList();
            }
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model) {
            if (model == null) {
                return null;
            }

            using (TypographyDatabase context = new TypographyDatabase()) {
                return context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
                    .ToList()
                    .Select(rec => new WarehouseViewModel {
                        Id = rec.Id,
                        WarehouseName = rec.WarehouseName,
                        WarehouseManagerFullName = rec.WarehouseManagerFullName,
                        DateCreate = rec.DateCreate,
                        WarehouseComponents = rec.WarehouseComponents
                            .ToDictionary(recWC => recWC.ComponentId,
                            recWC => (recWC.Component?.ComponentName,
                            recWC.Count))
                    })
                    .ToList();
            }
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model) {
            if (model == null) {
                return null;
            }

            using (TypographyDatabase context = new TypographyDatabase()) {
                Warehouse warehouse = context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName ||
                    rec.Id == model.Id);

                return warehouse != null ?
                    new WarehouseViewModel {
                        Id = warehouse.Id,
                        WarehouseName = warehouse.WarehouseName,
                        WarehouseManagerFullName = warehouse.WarehouseManagerFullName,
                        DateCreate = warehouse.DateCreate,
                        WarehouseComponents = warehouse.WarehouseComponents
                            .ToDictionary(recWC => recWC.ComponentId,
                            recWC => (recWC.Component?.ComponentName,
                            recWC.Count))
                    } :
                    null;
            }
        }

        public void Insert(WarehouseBindingModel model) {
            using (TypographyDatabase context = new TypographyDatabase()) {
                using (var transaction = context.Database.BeginTransaction()) {
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
            }
        }

        public void Update(WarehouseBindingModel model) {
            using (TypographyDatabase context = new TypographyDatabase()) {
                using (var transaction = context.Database.BeginTransaction()) {
                    try {
                        Warehouse warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                        if (warehouse == null) {
                            throw new Exception("Склад не найден");
                        }

                        CreateModel(model, warehouse, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(WarehouseBindingModel model) {
            using (TypographyDatabase context = new TypographyDatabase()) {
                Warehouse warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                if (warehouse == null) {
                    throw new Exception("Склад не найден");
                }
                context.Warehouses.Remove(warehouse);
                context.SaveChanges();
            }
        }

        public bool CheckRemove(Dictionary<int, (string, int)> components, int printedsCount) {
            using (TypographyDatabase context = new TypographyDatabase()) {
                using (var transaction = context.Database.BeginTransaction()) {
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
    }
}