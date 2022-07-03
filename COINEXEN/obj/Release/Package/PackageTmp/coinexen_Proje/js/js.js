
      var goster1 = document.getElementById("goster1");
      goster1.onclick = function () {
        //display özelliği none yapılarak gizleme işlemi yapılır.
        document.getElementById("first-div").style.display = "none";
        document.getElementById("erisim-ayarlari").style.display = "none";
        document.getElementById("onay-bildirim").style.display = "none";
        document.getElementById("iletisim-ayarlari").style.display = "none";

        document.getElementById("hesap-ayarlari").style.display = "block";
      };

      var goster2 = document.getElementById("goster2");
      goster2.onclick = function () {
        //display özelliği none yapılarak gizleme işlemi yapılır.
        document.getElementById("first-div").style.display = "none";
        document.getElementById("hesap-ayarlari").style.display = "none";
        document.getElementById("onay-bildirim").style.display = "none";
        document.getElementById("iletisim-ayarlari").style.display = "none";

        document.getElementById("erisim-ayarlari").style.display = "block";
      };

      var goster3 = document.getElementById("goster3");
      goster3.onclick = function () {
        //display özelliği none yapılarak gizleme işlemi yapılır.
        document.getElementById("first-div").style.display = "none";
        document.getElementById("hesap-ayarlari").style.display = "none";
        document.getElementById("erisim-ayarlari").style.display = "none";
        document.getElementById("iletisim-ayarlari").style.display = "none";

        document.getElementById("onay-bildirim").style.display = "block";
      };

      var goster4 = document.getElementById("goster4");
      goster4.onclick = function () {
        //display özelliği none yapılarak gizleme işlemi yapılır.
        document.getElementById("first-div").style.display = "none";
        document.getElementById("hesap-ayarlari").style.display = "none";
        document.getElementById("erisim-ayarlari").style.display = "none";
        document.getElementById("onay-bildirim").style.display = "none";

        document.getElementById("iletisim-ayarlari").style.display = "block";
      };

      var profilGoster = document.getElementById("profilGoster");
      profilGoster.onclick = function () {
    
    

        document.getElementById("ayarlar-profilBilgi").style.display = "block";
        document.getElementById("ayarlar-mobilBilgi").style.display = "none";
      };



      var profilKapat = document.getElementById("profilKapat");
      profilKapat.onclick = function () {
        
        document.getElementById("ayarlar-mobilBilgi").style.display = "block";
        document.getElementById("ayarlar-profilBilgi").style.display = "none";
      };