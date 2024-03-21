# TCDDBiletlemeAPI
Train Ticket Booking Service


Uygulamamız senaryo gereği bir tren bileti alınmasını sağlayacak API yapısına sahiptir. Projede MongoDB Kullanılacaktır.


“Başkent Ekspres”
“Ada Ekspres”
“Mavi Ekspres”
“Ege Ekspres”
“Fırat Ekspres”


* Bu hatlarda her trende 5 vagon her vagonda 20 kişi vardır ve ilk vagon VIP vagonlardır.


* Vagonlarda online bilet satışı tren mevcudunun %70’i olacaktır.


* Birden fazla rezervasyon isteği yapılabilmektedir.


* Rezervasyon isteği yapılırken, kişilerin farklı vagonlara yerleşip yerleştirilemeyeceği belirtilir. Bazı rezervasyonlarda tüm yolcuların aynı vagonda olması istenilirken, bazılarında farklı vagonlar da kabul edilebilir.


* Rezervasyon yapılabilir durumdaysa, API hangi vagonlara kaçar kişi yerleşeceği bilgisini dönecektir.



# API Request ve Response Formatı



Input formatı aşağıdaki gibidir. Rezervasyon istenilen trenin bilgileri, vagon ayrıntıları, kaç kişilik rezervasyon istenildiği ve kişilerin farklı vagonlara yerleştirilip yerleştirilemeyeceği bilgileri input içinde yer alır;


    {
        "Tren":
        {
            "Ad":"Başkent Ekspres",
            "Vagonlar":
            [
                {"Ad":"Vagon 1", "Kapasite":100, "DoluKoltukAdet":68},
                {"Ad":"Vagon 2", "Kapasite":90, "DoluKoltukAdet":50},
                {"Ad":"Vagon 3", "Kapasite":80, "DoluKoltukAdet":80}
            ]
        },
        "RezervasyonYapilacakKisiSayisi":3,
        "KisilerFarkliVagonlaraYerlestirilebilir":true
    }



Dönüş formatı aşağıdaki gibidir.



    {
        "RezervasyonYapilabilir":true,
        "YerlesimAyrinti":[
            {"VagonAdi":"Vagon 1","KisiSayisi":2},
            {"VagonAdi":"Vagon 2","KisiSayisi":1}
        ]
    }



Rezervasyon yapılamıyorsa YerlesimAyrinti bos array olacaktır; 



    {
        "RezervasyonYapilabilir”:false,
        "YerlesimAyrinti":[    ]
    }




