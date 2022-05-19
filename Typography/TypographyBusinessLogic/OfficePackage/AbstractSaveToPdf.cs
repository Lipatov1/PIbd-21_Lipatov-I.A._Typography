using TypographyBusinessLogic.OfficePackage.HelperEnums;
using TypographyBusinessLogic.OfficePackage.HelperModels;
using System.Collections.Generic;

namespace TypographyBusinessLogic.OfficePackage {
    public abstract class AbstractSaveToPdf {
        public void CreateDoc(PdfInfo info) {
            CreatePdf(info);

            CreateParagraph(new PdfParagraph {
                Text = info.Title,
                Style = "NormalTitle"
            });

            CreateParagraph(new PdfParagraph {
                Text = $"с { info.DateFrom.ToShortDateString() } по { info.DateTo.ToShortDateString() }",
                Style = "Normal"
            });

            CreateTable(new List<string> { "3cm", "3cm", "3cm", "3cm", "3cm", "3cm" });

            CreateRow(new PdfRowParameters {
                Texts = new List<string> { "Дата заказа", "ФИО клиента", "Изделие", "Количество", "Сумма", "Статус" },
                Style = "NormalTitle",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            foreach (var order in info.Orders) {
                CreateRow(new PdfRowParameters {
                    Texts = new List<string> { order.DateCreate.ToShortDateString(), order.ClientFIO, order.PrintedName, order.Count.ToString(), order.Sum.ToString(), order.Status.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
            }
            SavePdf(info);
        }

        public void CreateDocOrdersByDate(PdfInfo info) {
            CreatePdf(info);

            CreateParagraph(new PdfParagraph {
                Text = info.Title,
                Style = "NormalTitle"
            });

            CreateParagraph(new PdfParagraph {
                Text = $"Заказы по датам",
                Style = "Normal"
            });

            CreateTable(new List<string> { "3cm", "3cm", "3cm" });

            CreateRow(new PdfRowParameters {
                Texts = new List<string> { "Дата заказов", "Количество заказов", "Сумма" },
                Style = "NormalTitle",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            foreach (var order in info.OrdersByDate) {
                CreateRow(new PdfRowParameters {
                    Texts = new List<string> { order.DateCreate.ToShortDateString(), order.Count.ToString(), order.Sum.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
            }
            SavePdf(info);
        }

        //  Создание doc-файла
        protected abstract void CreatePdf(PdfInfo info);

        // Создание параграфа с текстом
        protected abstract void CreateParagraph(PdfParagraph paragraph);

        // Создание таблицы
        protected abstract void CreateTable(List<string> columns);

        // Создание и заполнение строки
        protected abstract void CreateRow(PdfRowParameters rowParameters);

        // Сохранение файла
        protected abstract void SavePdf(PdfInfo info);
    }
}