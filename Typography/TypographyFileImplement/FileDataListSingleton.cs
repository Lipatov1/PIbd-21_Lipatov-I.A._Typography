using TypographyContracts.Enums;
using TypographyFileImplement.Models;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using System;

namespace TypographyFileImplement {
    public class FileDataListSingleton {
        private static FileDataListSingleton instance;

        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string PrintedFileName = "Printed.xml";
        private readonly string WarehouseFileName = "Warehouse.xml";
        private readonly string ClientFileName = "Client.xml";
        private readonly string ImplementerFileName = "Implementer.xml";

        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Printed> Printeds { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<Warehouse> Warehouses { get; set; }

        private FileDataListSingleton() {
            Components = LoadComponents();
            Orders = LoadOrders();
            Printeds = LoadPrinteds();
            Warehouses = LoadWarehouses();
            Clients = LoadClients();
            Implementers = LoadImplementers();
        }

        public static FileDataListSingleton GetInstance() {
            if (instance == null) {
                instance = new FileDataListSingleton();
            }

            return instance;
        }

        public void Save() {
            SaveComponents();
            SaveOrders();
            SavePrinteds();
            SaveClients();
            SaveImplementers();
            SaveWarehouses();
        }

        private List<Component> LoadComponents() {
            var list = new List<Component>();

            if (File.Exists(ComponentFileName)) {
                var xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();

                foreach (var elem in xElements) {
                    list.Add(new Component {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }

        private List<Order> LoadOrders() {
            var list = new List<Order>();

            if (File.Exists(OrderFileName)) {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();

                foreach (var elem in xElements) {
                    list.Add(new Order {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PrintedId = Convert.ToInt32(elem.Element("PrintedId").Value),
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        ImplementerId = Convert.ToInt32(elem.Element("ImplementerId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Convert.ToInt32(elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null : Convert.ToDateTime(elem.Element("DateImplement").Value)
                    });
                }
            }

            return list;
        }

        private List<Printed> LoadPrinteds() {
            var list = new List<Printed>();

            if (File.Exists(PrintedFileName)) {
                var xDocument = XDocument.Load(PrintedFileName);
                var xElements = xDocument.Root.Elements("Printed").ToList();

                foreach (var elem in xElements) {
                    var printComp = new Dictionary<int, int>();

                    foreach (var component in elem.Element("PrintedComponents").Elements("PrintedComponent").ToList()) {
                        printComp.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }

                    list.Add(new Printed {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PrintedName = elem.Element("PrintedName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        PrintedComponents = printComp
                    });
                }
            }
            return list;
        }

        private List<Client> LoadClients() {
            var list = new List<Client>();

            if (File.Exists(ClientFileName)) {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();

                foreach (var elem in xElements) {
                    list.Add(new Client {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Login = elem.Element("Login").Value,
                        Password = elem.Element("Password").Value,
                    });
                }
            }

            return list;
        }

        private List<Implementer> LoadImplementers() {
            var list = new List<Implementer>();

            if (File.Exists(ImplementerFileName)) {
                XDocument xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();

                foreach (var elem in xElements) {
                    list.Add(new Implementer {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FIO = elem.Element("FIO").Value,
                        WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value)
                    });
                }
            }

            return list;
        }

        private List<Warehouse> LoadWarehouses() {
            var list = new List<Warehouse>();

            if (File.Exists(WarehouseFileName)) {
                XDocument xDocument = XDocument.Load(WarehouseFileName);
                var xElements = xDocument.Root.Elements("Warehouse").ToList();

                foreach (var warehouse in xElements) {
                    var warehouseComponents = new Dictionary<int, int>();

                    foreach (var component in warehouse.Element("WarehouseComponents").Elements("WarehouseComponent").ToList()) {
                        warehouseComponents.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }

                    list.Add(new Warehouse {
                        Id = Convert.ToInt32(warehouse.Attribute("Id").Value),
                        WarehouseName = warehouse.Element("WarehouseName").Value,
                        WarehouseManagerFullName = warehouse.Element("WarehouseManagerFullName").Value,
                        DateCreate = Convert.ToDateTime(warehouse.Element("DateCreate").Value),
                        WarehouseComponents = warehouseComponents
                    });
                }
            }

            return list;
        }

        private void SaveComponents() {
            if (Components != null) {
                var xElement = new XElement("Components");
                foreach (var component in Components) {
                    xElement.Add(new XElement("Component", new XAttribute("Id", component.Id), new XElement("ComponentName", component.ComponentName)));
                }

                var xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }

        private void SaveOrders() {
            if (Orders != null) {
                var xElement = new XElement("Orders");

                foreach (var order in Orders) {
                    xElement.Add(new XElement("Order",
                        new XAttribute("Id", order.Id),
                        new XElement("PrintedId", order.PrintedId),
                        new XElement("ClientId", order.ClientId),
                        new XElement("ImplementerId", order.ImplementerId),
                        new XElement("Count", order.Count),
                        new XElement("Sum", order.Sum),
                        new XElement("Status", (int)order.Status),
                        new XElement("DateCreate", order.DateCreate),
                        new XElement("DateImplement", order.DateImplement)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SavePrinteds() {
            if (Printeds != null) {

                var xElement = new XElement("Printeds");
                foreach (var printed in Printeds) {
                    var compElement = new XElement("PrintedComponents");

                    foreach (var component in printed.PrintedComponents) {
                        compElement.Add(new XElement("PrintedComponent", new XElement("Key", component.Key), new XElement("Value", component.Value)));
                    }

                    xElement.Add(new XElement("Printed", new XAttribute("Id", printed.Id), new XElement("PrintedName", printed.PrintedName), new XElement("Price", printed.Price), compElement));
                }

                var xDocument = new XDocument(xElement);
                xDocument.Save(PrintedFileName);
            }
        }

        private void SaveWarehouses() {
            if (Warehouses != null) {
                var xElement = new XElement("Warehouses");

                foreach (var warehouse in Warehouses) {
                    var compElement = new XElement("WarehouseComponents");

                    foreach (var component in warehouse.WarehouseComponents) {
                        compElement.Add(new XElement("WarehouseComponent",
                            new XElement("Key", component.Key),
                            new XElement("Value", component.Value)));
                    }

                    xElement.Add(new XElement("Warehouse",
                        new XAttribute("Id", warehouse.Id),
                        new XElement("WarehouseName", warehouse.WarehouseName),
                        new XElement("WarehouseManagerFullName", warehouse.WarehouseManagerFullName),
                        new XElement("DateCreate", warehouse.DateCreate.ToString()),
                        compElement));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(WarehouseFileName);
            }
        }

        private void SaveClients() {
            if (Clients != null) {
                var xElement = new XElement("Clients");

                foreach (var client in Clients) {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Login", client.Login),
                    new XElement("Password", client.Password)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }

        private void SaveImplementers() {
            if (Implementers != null) {
                var xElement = new XElement("Implementers");

                foreach (var implementer in Implementers) {
                    xElement.Add(new XElement("Implementer",
                        new XAttribute("Id", implementer.Id),
                        new XElement("FIO", implementer.FIO),
                        new XElement("WorkingTime", implementer.WorkingTime),
                        new XElement("PauseTime", implementer.PauseTime)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }
    }
}