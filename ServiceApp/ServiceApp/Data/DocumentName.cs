﻿namespace ServiceApp.Data
{
    public class DocumentName
    {

        public Dictionary<string, bool> documentH = new Dictionary<string, bool>()
        {
            { "Акт обследования и выбора трассы сети водоснабжения", false},
            { "Акт обследования и выбор места под проектируемую скважину",false},
            { "Согласованный ситуационный план (М1:10000 или М1:25000) с нанесением источников воды (скважин, родников и т.п.), существующих водонапорных башен, предполагаемой трассой водопровода и места врезки всуществующую сеть.", false},
            { "План населённого пункта в (М1:1000 или М 1:500 топографическая съёмка)",false },
            { "Технические условия на водоснабжение", false },
            { "Технические условия на электроснабжение (для насосной станции первого или второго подъема);", false },
            { "Градостроительный план земельного участка", false },
            { "Справка согласования с собственниками земельных участков", false },
            { "Документ, подтверждающий проведение межевания с присвоением кадастрового номера земельного участка под строительство водопровода и сооружений на нем.", false },
            { "заключение Органа Роспотребнадзора санитарно-эпидемиологической службы по отводу земельного участка и результат радиационного обследования.", false },
            { "Сведения о наличие водозаборных скважин (родников) на территории хозяйства.", false }
        };

        public Dictionary<string, bool> documentG = new Dictionary<string, bool>()
        {
            { "Письмо-обращение на имя Президента,Премьер-Министра, Минстрой РТ", false },
            { "Задание на проектирование", false },
            { "Ситуационный план (утвержденный исполкомом)", false },
            { "Технические условия на присоединение к газораспределительной сети (№, дата,срок действий Технических условий)", false },
            { "Технический паспорт (план БТИ) объекта СКБ", false },
            { "АКТ обследования объекта", false },
            { "Технические условия на сети электроснабжение, водоснабжения, водоотведения при установке БМК", false },
            { "Согласование посадки котельной", false }
        };

        public Dictionary<string, bool> documentHDes = new Dictionary<string, bool>()
        {
            { "Технико-экономические показатели (ТЭП)", false }
        };

        public Dictionary<string, bool> documentGDes = new Dictionary<string, bool>()
        {
            { "Технико-экономические показатели (ТЭП)", false },
            { "Вводной газопровод низкого давления", false }
        };
    }
}
