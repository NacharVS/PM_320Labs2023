using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Tenders.Data.Users;

namespace Tenders.Data;

public class Project
{
    [BsonId] public ObjectId Id;
    [BsonIgnoreIfDefault] public Developer Developer;
    [BsonIgnoreIfDefault] public Designer Designer;
    [BsonIgnoreIfDefault] public Customer Customer;
    [BsonIgnoreIfDefault] public IndustryType IndustryType;
    [BsonIgnoreIfDefault] public List<Document> DocumentsForDeveloper;
    [BsonIgnoreIfDefault] public List<Document> DocumentsForDesigner;

    public Project(Customer customer)
    {
        Customer = customer;
        IndustryType = customer.IndustryType;
        if (IndustryType == IndustryType.GasSupply)
        {
            FillGasSupplyDocuments();
        }
        else
        {
            FillWaterSupplyDocuments();
        }
    }

    private void FillWaterSupplyDocuments()
    {
        DocumentsForDeveloper = new List<Document>()
        {
            new Document("Акт обследования и выбора трассы сети водоснабжения"),
            new Document("Акт обследования и выбор места под проектируемую скважину"),
            new Document("Согласованный ситуационный план (М1:10000 или М1:25000) с нанесением источников воды (скважин, родников и т.п.), существующих водонапорных башен, предполагаемой трассой водопровода и места врезки в существующую сеть"),
            new Document("План населённого пункта в М 1:1000 или М 1:500 топографическая съемка"),
            new Document("технические условия на водоснабжение"),
            new Document("Технические условия на электроснабжение (для насосной станции первого или второго подъема)"),
            new Document(" Градостроительный план земельного участка"),
            new Document("Справка согласования с собственниками земельных участков"),
            new Document("документ, подтверждающий проведение межевания с присвоением кадастрового номера земельного участка под строительство водопровода и сооружений на нем"),
            new Document("заключение Органа Роспотребнадзора санитарно-эпидемиологической службы по отводу земельного участка и результат радиационного обследования"),
            new Document("Сведения о наличие водозаборных скважин (родников) на территории хозяйства")
        };

        DocumentsForDesigner = new List<Document>()
        {
            new Document("Технико-экономические показатели (ТЭП)")
        };
    }

    private void FillGasSupplyDocuments()
    {
        DocumentsForDeveloper = new List<Document>()
        {
            new Document("Письмо-обращение на имя Президента, Премьер-Министра, Минстрой РТ"),
            new Document("Задание на проектирование"),
            new Document("Ситуационный план (утвержденный исполкомом)"),
            new Document("Технические условия на присоединение к газораспределительной сети (№, дата, срок действий Технических условий)"),
            new Document("Технический паспорт (план БТИ) объекта СКБ"),
            new Document("Технический паспорт (план БТИ) существующей котельной"),
            new Document("АКТ обследования объекта"),
            new Document("Технические условия на сети электроснабжение, водоснабжения, водоотведения при установке БМК"),
            new Document("Согласование посадки котельной")
        };

        DocumentsForDesigner = new List<Document>()
        {
            new Document("Технико-экономические показатели (ТЭП) Газопровод-ввод низкого давления"),
            new Document("Вводной газопровод низкого давления")
        };
    }
}