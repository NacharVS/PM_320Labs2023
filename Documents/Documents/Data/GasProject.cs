using System.Collections.Generic;

namespace Documents.Data
{
    public class GasProject : Project
    {
        public GasProject()
        {
            BuilderDocumentInfos = new List<DocumentInfo>
            {
                new DocumentInfo() {Name ="Письмо-обращение на имя Президента, Премьер-Министра, Минстрой РТ"},
                new DocumentInfo() {Name ="Задание на проектирование"},
                new DocumentInfo() {Name ="Ситуационный план (утвержденный исполкомом)"},
                new DocumentInfo() {Name ="Технические условия на присоединение к газораспределительной сети " +
                "(№, дата, срок действий Технических условий)"},
                new DocumentInfo() {Name ="Технический паспорт (план БТИ) объекта СКБ"},
                new DocumentInfo() {Name ="Технический паспорт (план БТИ) существующей котельной"},
                new DocumentInfo() {Name ="АКТ обследования объекта"},
                new DocumentInfo() {Name ="Технические условия на сетиэлектроснабжение, водоснабжения" +
                ",водоотведения при установке БМК"},
                new DocumentInfo() {Name ="Согласование посадки котельной "}
            };

            ArchitectDocumentInfos = new List<DocumentInfo>
            {
                new DocumentInfo() {Name = "Смета на ПиР"},
                new DocumentInfo() {Name = "График проектирования"}
            };

            FormInfos = new List<FormInfo>
            {
                new FormInfo() {Name = "Технико-экономические показатели (ТЭП)"},
                new FormInfo() {Name = "Диаметр (мм) трубопровода и протяженность линейного объекта (м)"},
                new FormInfo() {Name = "Вводной газопровод низкого давления"},
                new FormInfo() {Name = "Диаметр (мм) трубопровода и протяженность линейного объекта (м)"},
                new FormInfo() {Name = "Сметная стоимость работ, тыс. руб."},
                new FormInfo() {Name = "Срок разработки проектной документации, месяцев"}
            };

            Department_ID = "636ea3c8f6650224b7894d94";
        }
    }
}