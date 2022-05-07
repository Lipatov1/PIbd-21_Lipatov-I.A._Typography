using TypographyBusinessLogic.OfficePackage.HelperModels;
using TypographyBusinessLogic.OfficePackage.HelperEnums;
using System.Collections.Generic;

namespace TypographyBusinessLogic.OfficePackage {
    public abstract class AbstractSaveToWord {
        public void CreateDoc(WordInfo info) {
            CreateWord(info);

            CreateParagraph(new WordParagraph {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            foreach (var component in info.Printeds) {
                CreateParagraph(new WordParagraph {
                    Texts = new List<(string, WordTextProperties)> { (component.PrintedName, new WordTextProperties { Bold = true, Size = "24", }),
                     (" Цена " + component.Price.ToString(), new WordTextProperties {Bold = false, Size = "24"})
                    },
                    TextProperties = new WordTextProperties {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }

            SaveWord(info);
        }

        public void CreateDocWarehouse(WordInfo info) {
            CreateWord(info);

            CreateParagraph(new WordParagraph {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24" }) },
                TextProperties = new WordTextProperties {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            CreateTable(new List<string>() { "Название", "ФИО ответственного", "Дата создания" });

            foreach (var warehouse in info.Warehouses) {
                AddRowTable(new List<string>() {
                    warehouse.WarehouseName,
                    warehouse.WarehouseManagerFullName,
                    warehouse.DateCreate.ToShortDateString()
                });
            }
            SaveWord(info);
        }

        // Создание doc-файла
        protected abstract void CreateWord(WordInfo info);

        // Создание абзаца с текстом
        protected abstract void CreateParagraph(WordParagraph paragraph);

        // Сохранение файла
        protected abstract void SaveWord(WordInfo info);
        protected abstract void CreateTable(List<string> tableHeaderInfo);
        protected abstract void AddRowTable(List<string> tableRowInfo);
    }
}