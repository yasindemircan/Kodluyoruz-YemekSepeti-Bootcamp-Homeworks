using System;

namespace cleanCode
{
    class Program
    {
        static void Main(string[] args)
        {
            #region isimlendirmeler
                // Değişken yada method isimlendirmeleri anlamsız yada kısaltmalar kullanılarak yapılmamalı, değişken yada method isminden
                // ne için oluşturulduğunu anlatmalıdır.
                string u = "htttp:......." x
                string Base_Url = "http:....." ✓

                public string Url(string Base_Url, string Path){} x
                public string UrlCreator(string Base_Url, string Path) ✓
            #endregion

            #region Boolean karsılaştırmalar
                    // buradakı iki kodda aynı iş yapmakta sadece ilk kod daha uzun yazılmış şeklini görüyoruz, kodu olabildiğince kısa ve okunaklı yazmak olmalı hedefimiz.
                if(loggedIn == true) x
                if(loggedIn) ✓
            #endregion

            #region Boolean değişken etkin kullanımı 
                    if(totalWalletPoint > 100 && userActive) x
                                                                    // ifadeyi bool değişene bölerek yazmak daha okunaklı bir yazış şekli olucaktır.
                    bool UserCanGetGift = totalWalletPoint > 100 && userActive 
                    if(UserCanGetGift) ✓
            #endregion

            #region Pozitiflik
                    // ikiside ayni işlemi yapıyor ancak ilkinde değilin değili gibi bir anlam oluşmuş, düzgün ve pozitif düşünerek bu tarz durumları güzel ifade etmeliyiz.  
                if(!fileDataNot) x
                if(fileData) ✓
            #endregion

            #region TernaryIf
                if(theme ==  dark)
                {theme.color ="#fffff"}
                else{theme.color = "#00000"} x
                                                // koşul ifademizi daha kısa ve okunaklı şeklide yazmış olduk.
                theme  == dark ? theme.color ="#fffff": theme.color ="#00000" ✓
            #endregion

            #region stringly type kullanımından kaçınmak
                if(select == "apple") x
                            // eğer yukarıdaki gibi koşul içerisinde string bir değer yazarsak bir baskası gelip aynı nesne için karşılaştırma yaptıgında aynı sekilde 
                            // yazması gerekmetedir, bu da programcı için ekstra ögrenmesi gereken bir bilgi demektir bu tarz durumlardan kacınmak için bir 
                            // reference üzerinde değişkenleri tutmak en iyisidir. 
                if(select == fruits.apple) ✓
            #endregion

            #region anlamsız ifadeler
                if(totalPoint > 100) x
                    // koşul içersinden bir anlam belirtmeyen ifadelerden kaçınmak, örneğin yukarıda 100 den büyükse ifadesi kullandık ancak 100 den büyükse ne olacak 
                    // bunu belirten bir bilgi yok ortada bu yüzden aşağıdaki gibi kullanarak 100 den büyükse seviye 1 i bitirmiştir anlamında bir kod yazdık.
                int level_1 = 100;
                if(totalPoint > level_1) ✓
            #endregion

            #region Dogru yerde Dogru şeyleri kullanmak
             x public void SendEmailToListOfClients(string[] clients)
                {
                    foreach (var client in clients)
                    {
                        var clientRecord = db.Find(client);
                        if (clientRecord.IsActive())
                        {
                            Email(client);
                        }
                    }
                }
                    // fonksiyonları olabildiğince bölmek gerekli, burada yukarıdaki kullanımda foreach yapısı kullanılırak liste içersinde arama yapıyoruz ancak aşağıdaki
                    // kullanımda görüldüğü üzeri linq paketiyle foreach yazarak uzatmadan bu işlem yapılabilir, bizim öncelikli amacımız sadelik ve okunabilirlik oldugundan 
                    // aşağıdaki kullanım daha doğru olacaktır.
              ✓  public void SendEmailToListOfClients(string[] clients)
                {
                    var activeClients = GetActiveClients(clients);
                    // Do some logic
                }

                public List<Client> GetActiveClients(string[] clients)
                {
                    return db.Find(clients).Where(s => s.Status == "Active");
                }
            #endregion

            #region just in time
            string username ="yasin";
            string pass = "aaaa";
            if(username != db.username)
                return false;
            if(pass != db.pass)
                return false;
            return true;
                    // yukarıdaki gibi bütün değişkenleri en üst kısımda tanımlamak okunabilirliği düşürüyor bunun yerine değişkeni kullanmadan 
                    // hemen öncesinde tanımlamak okunabilirlik açısından daha dogru olacaktır
            string username ="yasin";
            if(username != db.username)
                return false;
            string pass ="aaaa";
            if(pass != db.pass)
                return false;
            return true; 
            #endregion

        #region Exctract Method
                // kod blogu en sade haline gelene kadar methodlara bölmek
               if()
                {
                if()
                    {
                        do
                        {
                          //islemler
                        } while()
                    }
                }
                //----------------
                if()
                {
                if()
                {
                    DoSomething();
                }
                }
                private void DoSomething()
                {
                do 
                { 
                    //islemler
                } while()
                }
        #endregion

            #region Fail Fast
            // ilk önce oluşabilecek hataları yakalayarak erkenden hatayı geri döndürmek  sonrasında yapılacak işleri yapmak.
            if(username == db.username){
                if(pass == db.pass){
                    showData();
                }else{
                    throw pass hatalı
                }
            }else{
                throw username hatalı
            }

                    // --------------------

            if(username != db.username)
               throw username hatalı
            if(pass != db.pass)
                throw pass hatalı
            showData();

        #endregion

            





            Console.WriteLine("Clean Code!");
        }
    }
}
