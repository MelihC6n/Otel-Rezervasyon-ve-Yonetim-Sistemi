using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace OtelRezervasyon
{
    public class DbProcess
    {

        SqlConnection con = new SqlConnection("Server = DESKTOP-7JCKATF\\MELIH; Database = OtelRezervasyon; Trusted_Connection = True; ");

        #region Konuk
        public void KonukInsert(Konuk konukDegisken)
        {
            SqlCommand insert = new SqlCommand("insert into Konuk(MusteriID,Ad,Soyad,Cinsiyet) values(@MusteriID,@Ad,@Soyad,@Cinsiyet)", con);
            insert.Parameters.AddWithValue("@MusteriID", konukDegisken.musteriID);
            insert.Parameters.AddWithValue("@Ad", konukDegisken.ad);
            insert.Parameters.AddWithValue("@Soyad", konukDegisken.soyad);
            insert.Parameters.AddWithValue("@Cinsiyet", konukDegisken.cinsiyet);
            KomutCalistir(insert);
        }

        public void KonukUpdate(Konuk konukDegisken)
        {
            SqlCommand update = new SqlCommand("update Konuk set MusteriID=@MusteriID,Ad=@Ad,Soyad=@Soyad,Cinsiyet=@Cinsiyet where ID=@ID", con);
            update.Parameters.AddWithValue("@MusteriID", konukDegisken.musteriID);
            update.Parameters.AddWithValue("@Ad", konukDegisken.ad);
            update.Parameters.AddWithValue("@Soyad", konukDegisken.soyad);
            update.Parameters.AddWithValue("@Cinsiyet", konukDegisken.cinsiyet);
            update.Parameters.AddWithValue("@ID", konukDegisken.id);
            KomutCalistir(update);
        }

        public void KonukDelete(Konuk konukDegisken)
        {
            SqlCommand delete = new SqlCommand("delete from Konuk where ID=@ID", con);
            delete.Parameters.AddWithValue("@ID", konukDegisken.id);
            KomutCalistir(delete);
        }

        public List<Konuk> KonukSelect()
        {
            List<Konuk> result = new List<Konuk>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Konuk", con);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Konuk konuk = new Konuk(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    musteriID = Convert.ToInt32(dr[1]),
                    ad = Convert.ToString(dr[2]),
                    soyad = Convert.ToString(dr[3]),
                    cinsiyet = Convert.ToBoolean(dr[4])
                };
                result.Add(konuk);
            }
            con.Close();
            return result;
        }
        #endregion

        #region Müşteri
        public void MusteriInsert(Musteri musteriDegisken)
        {
            SqlCommand insert = new SqlCommand("insert into Musteri(Ad,Soyad,Eposta,CepTelefon,Cinsiyet,Ulke,Uyruk) values(@Ad,@Soyad,@Eposta,@CepTelefon,@Cinsiyet,@Ulke,@Uyruk)", con);
            insert.Parameters.AddWithValue("@Ad", musteriDegisken.ad);
            insert.Parameters.AddWithValue("@Soyad", musteriDegisken.soyad);
            insert.Parameters.AddWithValue("@Eposta", musteriDegisken.ePosta);
            insert.Parameters.AddWithValue("@CepTelefon", musteriDegisken.cepTelefon);
            insert.Parameters.AddWithValue("@Cinsiyet", musteriDegisken.cinsiyet);
            //insert.Parameters.AddWithValue("@Notlar", musteriDegisken.notlar);
            //insert.Parameters.AddWithValue("@KonukSayisi", musteriDegisken.konukSayisi);
            insert.Parameters.AddWithValue("@Ulke", musteriDegisken.ulke);
            insert.Parameters.AddWithValue("@Uyruk", musteriDegisken.uyruk);
            KomutCalistir(insert);
        }

        public void MusteriUpdate(Musteri musteriDegisken)
        {
            SqlCommand update = new SqlCommand("update Musteri set Ad=@Ad,Soyad=@Soyad,Eposta=@Eposta,CepTelefon=@CepTelefon,Cinsiyet=@Cinsiyet,Notlar=@Notlar,KonukSayisi=@KonukSayisi,Ulke=@Ulke,Uyruk=@Uyruk where ID=@ID", con);
            update.Parameters.AddWithValue("@Ad", musteriDegisken.ad);
            update.Parameters.AddWithValue("@Soyad", musteriDegisken.soyad);
            update.Parameters.AddWithValue("@Eposta", musteriDegisken.ePosta);
            update.Parameters.AddWithValue("@CepTelefon", musteriDegisken.cepTelefon);
            update.Parameters.AddWithValue("@Cinsiyet", musteriDegisken.cinsiyet);
            update.Parameters.AddWithValue("@Notlar", musteriDegisken.notlar);
            update.Parameters.AddWithValue("@KonukSayisi", musteriDegisken.konukSayisi);
            update.Parameters.AddWithValue("@Ulke", musteriDegisken.ulke);
            update.Parameters.AddWithValue("@Uyruk", musteriDegisken.uyruk);
            update.Parameters.AddWithValue("@ID", musteriDegisken.id);
            KomutCalistir(update);
        }

        public void MusteriDelete(Musteri musteriDegisken)
        {
            SqlCommand delete = new SqlCommand("delete from Musteri where ID=@ID", con);
            delete.Parameters.AddWithValue("@ID", musteriDegisken.id);
            KomutCalistir(delete);
        }

        public List<Musteri> MusteriSelect()
        {
            List<Musteri> result = new List<Musteri>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Musteri", con);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Musteri musteri = new Musteri(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    ad = Convert.ToString(dr[1]),
                    soyad = Convert.ToString(dr[2]),
                    ePosta = Convert.ToString(dr[3]),
                    cepTelefon = Convert.ToString(dr[4]),
                    cinsiyet = Convert.ToBoolean(dr[5]),
                    notlar = Convert.ToString(dr[6]),
                    konukSayisi = Convert.ToInt32(dr[7]),
                    ulke = Convert.ToString(dr[8]),
                    uyruk = Convert.ToString(dr[8])
                };
                result.Add(musteri);
            }
            con.Close();
            return result;
        }

        public int MusteriIdGetirInsert(Musteri arananMusteri)
        {
            int result;
            con.Open();
            SqlCommand komut = new SqlCommand("insert into Musteri(Ad,Soyad,Eposta,CepTelefon,Cinsiyet,Ulke,Uyruk) output INSERTED.ID values(@Ad,@Soyad,@Eposta,@CepTelefon,@Cinsiyet,@Ulke,@Uyruk)", con);
            //select ID from Musteri where Ad=@Ad and Soyad=@Soyad and Eposta=@Eposta and CepTelefon=@CepTelefon and Ulke=@Ulke and Uyruk=@Uyruk
            komut.Parameters.AddWithValue("@Ad", arananMusteri.ad);
            komut.Parameters.AddWithValue("@Soyad", arananMusteri.soyad);
            komut.Parameters.AddWithValue("@Eposta", arananMusteri.ePosta);
            komut.Parameters.AddWithValue("@CepTelefon", arananMusteri.cepTelefon);
            komut.Parameters.AddWithValue("@Cinsiyet", arananMusteri.cinsiyet);
            komut.Parameters.AddWithValue("@Ulke", arananMusteri.ulke);
            komut.Parameters.AddWithValue("@Uyruk", arananMusteri.uyruk);
            result=Convert.ToInt32(komut.ExecuteScalar());
            //SqlDataReader dr = komut.ExecuteReader();
            //while (dr.Read())
            //{
            //    Musteri musteri = new Musteri(null)
            //    {
            //        id = Convert.ToInt32(dr[0])
            //    };
            //    result.Add(musteri);
            //}
            con.Close();
            return result;
        }
        #endregion

        #region Rezervasyon
        public void RezervasyonInsert(Rezervasyon rezervasyonDegisken)
        {
            SqlCommand insert = new SqlCommand("insert into Rezervasyon(GelisAmaci,MusteriID,GelisTarihi,GidisTarihi,RezervasyonTarihi,RezervasyonKodu,OdaID,IndirimOrani,Ucret) values(@GelisAmaci,@MusteriID,@GelisTarihi,@GidisTarihi,@RezervasyonTarihi,@RezervasyonKodu,@OdaID,@IndirimOrani,@Ucret)", con);
            insert.Parameters.AddWithValue("@GelisAmaci", rezervasyonDegisken.gelisAmaci);
            insert.Parameters.AddWithValue("@MusteriID", rezervasyonDegisken.musteriID);
            insert.Parameters.AddWithValue("@GelisTarihi", rezervasyonDegisken.gelisTarihi);
            insert.Parameters.AddWithValue("@GidisTarihi", rezervasyonDegisken.gidisTarihi);
            insert.Parameters.AddWithValue("@RezervasyonTarihi", Convert.ToDateTime(rezervasyonDegisken.rezervasyonTarihi));
            insert.Parameters.AddWithValue("@RezervasyonKodu", rezervasyonDegisken.rezervasyonKodu);
            insert.Parameters.AddWithValue("@OdaID", rezervasyonDegisken.odaID);
            insert.Parameters.AddWithValue("@IndirimOrani", rezervasyonDegisken.indirimOrani);
            insert.Parameters.AddWithValue("@Ucret", rezervasyonDegisken.ucret);
            KomutCalistir(insert);
        }

        public void RezervasyonUpdate(Rezervasyon rezervasyonDegisken)
        {
            SqlCommand update = new SqlCommand("update Rezervasyon set GelisAmaci=@GelisAmaci,MusteriID=@MusteriID,GelisTarihi=@GelisTarihi,GidisTarihi=@GidisTarihi,RezervasyonTarihi=@RezervasyonTarihi,RezervasyonKodu=@RezervasyonKodu,OdaID=@OdaID,IndirimOrani=@IndirimOrani where ID=@ID", con);
            update.Parameters.AddWithValue("@GelisAmaci", rezervasyonDegisken.gelisAmaci);
            update.Parameters.AddWithValue("@MusteriID", rezervasyonDegisken.musteriID);
            update.Parameters.AddWithValue("@GelisTarihi", rezervasyonDegisken.gelisTarihi);
            update.Parameters.AddWithValue("@GidisTarihi", rezervasyonDegisken.gidisTarihi);
            update.Parameters.AddWithValue("@RezervasyonTarihi", rezervasyonDegisken.rezervasyonTarihi);
            update.Parameters.AddWithValue("@RezervasyonKodu", rezervasyonDegisken.rezervasyonKodu);
            update.Parameters.AddWithValue("@OdaID", rezervasyonDegisken.odaID);
            update.Parameters.AddWithValue("@IndirimOrani", rezervasyonDegisken.indirimOrani);
            update.Parameters.AddWithValue("@ID", rezervasyonDegisken.id);
            KomutCalistir(update);
        }

        public void RezervasyonDelete(Rezervasyon rezervasyonDegisken)
        {
            SqlCommand delete = new SqlCommand("update Rezervasyon set IsActive=0 where RezervasyonKodu=@rezervasyonKodu", con);//ID yerine RezKod aldım
            delete.Parameters.AddWithValue("@rezervasyonKodu", rezervasyonDegisken.rezervasyonKodu);
            KomutCalistir(delete);
        }

        public void RezervasyonCheckIn(Rezervasyon rezervasyonDegisken)
        {
            SqlCommand rezCheck = new SqlCommand("update Rezervasyon set IsActive=0 where ID=@ID", con);//ID yerine RezKod aldım
            rezCheck.Parameters.AddWithValue("@ID", rezervasyonDegisken.id);
            KomutCalistir(rezCheck);
        }

        public List<Rezervasyon> RezervasyonSelect()
        {
            List<Rezervasyon> result = new List<Rezervasyon>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Rezervasyon where IsActive=1", con);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Rezervasyon rezervasyon = new Rezervasyon(null, null)
                {

                    id = Convert.ToInt32(dr[0]),
                    gelisAmaci = Convert.ToBoolean(dr[1]),
                    musteriID = Convert.ToInt32(dr[2]),
                    gelisTarihi = Convert.ToDateTime(dr[3]),
                    gidisTarihi = Convert.ToDateTime(dr[4]),
                    rezervasyonTarihi = Convert.ToString(dr[5]),
                    rezervasyonKodu = Convert.ToString(dr[6]),
                    odaID = Convert.ToInt32(dr[7]),
                    ucret = Convert.ToDouble(dr[8])
                };
                result.Add(rezervasyon);
            }
            con.Close();
            return result;
        }

        public List<Rezervasyon> RezervasyonSorgulaSelect(Rezervasyon rez)
        {
            List<Rezervasyon> result = new List<Rezervasyon>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from rezervasyonSorgulaView where RezervasyonKodu=@rezKod", con);
            komut.Parameters.AddWithValue("@rezKod", rez.rezervasyonKodu);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                OdaTip odaTip = new OdaTip(null)
                {
                    ad = Convert.ToString(dr[3]),
                };
                Odalar odalar = new Odalar(null, odaTip);

                Rezervasyon rezervasyon = new Rezervasyon(null, odalar)
                {
                    gelisTarihi = Convert.ToDateTime(dr[0]),
                    gidisTarihi = Convert.ToDateTime(dr[1]),
                    rezervasyonTarihi = Convert.ToString(dr[2]),
                    indirimOrani = int.Parse(dr[4].ToString()),
                    odaID= int.Parse(dr[6].ToString())
                };

                result.Add(rezervasyon);
            }
            con.Close();
            return result;
        }

        public List<Rezervasyon> RezervasyonViewSelect(Rezervasyon rezTarihi,Musteri arananMusteri)
        {
            List<Rezervasyon> result = new List<Rezervasyon>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from RezervasyonView where GelisTarihi='"+ rezTarihi.gelisTarihi.Date.ToString("yyyy-MM-dd ") + "' and Ad like '"+ arananMusteri.ad + "%'", con);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Musteri musteri = new Musteri(null)
                {
                    ad = Convert.ToString(dr[3]),
                    soyad = Convert.ToString(dr[4]),
                    ulke = Convert.ToString(dr[5]),
                    uyruk = Convert.ToString(dr[6]),
                    cepTelefon = Convert.ToString(dr[7]),
                };
                Rezervasyon rezervasyon = new Rezervasyon(musteri,null)
                {
                    gelisTarihi = Convert.ToDateTime(dr[0]),
                    gidisTarihi = Convert.ToDateTime(dr[1]),
                    rezervasyonTarihi = Convert.ToString(dr[2]),
                    indirimOrani = Convert.ToInt32(dr[8]),
                    odaID= Convert.ToInt32(dr[9]),
                    id= Convert.ToInt32(dr[10]),
                    ucret=Convert.ToDouble(dr[11])
                };
                result.Add(rezervasyon);
            }
            con.Close();
            return result;
        }

        public DataTable RezervasyonViewSelectPDF(Rezervasyon rezTarihi, Musteri arananMusteri)
        {
            DataTable result = new DataTable();
            con.Open();
            SqlDataAdapter komut = new SqlDataAdapter("select GelisTarihi,GidisTarihi,RezervasyonTarihi,Ad,Soyad,Ulke,Uyruk,CepTelefon,IndirimOrani from RezervasyonView where GelisTarihi='" + rezTarihi.gelisTarihi.Date.ToString("yyyy-MM-dd ") + "' and Ad like '" + arananMusteri.ad + "%'", con);
            komut.Fill(result);
            con.Close();
            return result;
        }
        #endregion

        #region Odalar
        public void OdalarInsert(Odalar odalarDegisken)
        {
            SqlCommand insert = new SqlCommand("insert into Odalar(OtelID,OdaNo,TipID,Kat) values(@OtelID,@OdaNo,@TipID,@Kat)", con);
            insert.Parameters.AddWithValue("@OtelID", odalarDegisken.otelID);
            insert.Parameters.AddWithValue("@Kat", odalarDegisken.kat);
            insert.Parameters.AddWithValue("@OdaNo", odalarDegisken.odaNo);
            insert.Parameters.AddWithValue("@TipID", odalarDegisken.tipID);
            KomutCalistir(insert);
        }

        public void OdalarUpdate(Odalar odalarDegisken)
        {

            SqlCommand update = new SqlCommand("update Odalar set TipID=@TipID where OdaNo=@OdaNo", con);
            update.Parameters.AddWithValue("@TipID", odalarDegisken.tipID);
            update.Parameters.AddWithValue("@OdaNo", odalarDegisken.odaNo);
            KomutCalistir(update);
        }

        public void OdalarDelete(Odalar odalarDegisken)
        {
            SqlCommand delete = new SqlCommand("delete from Odalar where ID=@ID", con);
            delete.Parameters.AddWithValue("@ID", odalarDegisken.id);
            KomutCalistir(delete);
        }

        public List<Odalar> OdalarSelect()
        {
            List<Odalar> result = new List<Odalar>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Odalar", con);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Odalar odalar = new Odalar(null, null)
                {

                    id = Convert.ToInt32(dr[0]),
                    otelID = Convert.ToInt32(dr[1]),
                    odaNo = Convert.ToInt32(dr[2]),
                    kat=Convert.ToInt32(dr[3]),
                    tipID = Convert.ToInt32(dr[4])
                };
                result.Add(odalar);
            }
            con.Close();
            return result;
        }

        public List<Odalar> OdalarSelectTekOda(Odalar oda)
        {
            List<Odalar> result = new List<Odalar>();
            con.Open();
            SqlCommand komut = new SqlCommand("select OdaNo,Kat,TipID from Odalar where ID=@ID", con);
            komut.Parameters.AddWithValue("@ID", oda.id);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Odalar odalar = new Odalar(null, null)
                {
                    odaNo = Convert.ToInt32(dr[0]),
                    kat=Convert.ToInt32(dr[1]),
                    tipID = Convert.ToInt32(dr[2])
                };
                result.Add(odalar);
            }
            con.Close();
            return result;
        }

        public Odalar OdalarNoyuIdyeCevir(Odalar oda)
        {
            Odalar result = new Odalar(null, null);
            con.Open();
            SqlCommand komut = new SqlCommand("select ID from Odalar where OdaNo=@OdaNo", con);
            komut.Parameters.AddWithValue("@OdaNo", oda.odaNo);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                result.id = Convert.ToInt32(dr[0]);
            }
            con.Close();
            return result;
        }
        #endregion

        #region OdaÖzellik
        public void OdaOzellikInsert(OdaOzellik odaOzellikDegisken)
        {
            SqlCommand insert = new SqlCommand("insert into OdaOzellik(TipID,Klima,Sauna,Televizyon,ManzaraTip,SacKurutmaMakinasi,Jakuzi,SesYalitimi,Mutfak,Balkon) values(@TipID,@Klima,@Sauna,@Televizyon,@ManzaraTip,@SacKurutmaMakinasi,@Jakuzi,@SesYalitimi,@Mutfak,@Balkon)", con);
            insert.Parameters.AddWithValue("@TipID", odaOzellikDegisken.tipID);
            insert.Parameters.AddWithValue("@Klima", odaOzellikDegisken.klima);
            insert.Parameters.AddWithValue("@Sauna", odaOzellikDegisken.sauna);
            insert.Parameters.AddWithValue("@Televizyon", odaOzellikDegisken.televizyon);
            insert.Parameters.AddWithValue("@ManzaraTip", odaOzellikDegisken.manzaraId);
            insert.Parameters.AddWithValue("@SacKurutmaMakinasi", odaOzellikDegisken.sacKurutmaMakinasi);
            insert.Parameters.AddWithValue("@Jakuzi", odaOzellikDegisken.jakuzi);
            insert.Parameters.AddWithValue("@SesYalitimi", odaOzellikDegisken.sesYalitimi);
            insert.Parameters.AddWithValue("@Mutfak", odaOzellikDegisken.mutfak);
            insert.Parameters.AddWithValue("@Balkon", odaOzellikDegisken.balkon);
            KomutCalistir(insert);
        }

        public void OdaOzellikUpdate(OdaOzellik odaOzellikDegisken)
        {
            SqlCommand update = new SqlCommand("update OdaOzellik set Klima=@Klima,Sauna=@Sauna,Televizyon=@Televizyon,ManzaraTip=@ManzaraTip,SacKurutmaMakinasi=@SacKurutmaMakinasi,Jakuzi=@Jakuzi,SesYalitimi=@SesYalitimi,Mutfak=@Mutfak,Balkon=@Balkon where TipID=@TipID", con);
            update.Parameters.AddWithValue("@Klima", odaOzellikDegisken.klima);
            update.Parameters.AddWithValue("@Sauna", odaOzellikDegisken.sauna);
            update.Parameters.AddWithValue("@Televizyon", odaOzellikDegisken.televizyon);
            update.Parameters.AddWithValue("@ManzaraTip", odaOzellikDegisken.manzaraId);
            update.Parameters.AddWithValue("@SacKurutmaMakinasi", odaOzellikDegisken.sacKurutmaMakinasi);
            update.Parameters.AddWithValue("@Jakuzi", odaOzellikDegisken.jakuzi);
            update.Parameters.AddWithValue("@SesYalitimi", odaOzellikDegisken.sesYalitimi);
            update.Parameters.AddWithValue("@Mutfak", odaOzellikDegisken.mutfak);
            update.Parameters.AddWithValue("@Balkon", odaOzellikDegisken.balkon);
            update.Parameters.AddWithValue("@TipID", odaOzellikDegisken.tipID);
            KomutCalistir(update);
        }

        public void OdaOzellikDelete(OdaOzellik odaOzellikDegisken)
        {
            SqlCommand delete = new SqlCommand("delete from OdaOzellik where ID=@ID", con);
            delete.Parameters.AddWithValue("@ID", odaOzellikDegisken.id);
            KomutCalistir(delete);
        }

        public List<OdaOzellik> OdaOzellikSelect()
        {
            List<OdaOzellik> result = new List<OdaOzellik>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from OdaOzellik", con);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                OdaOzellik odaOzellik = new OdaOzellik(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    tipID = Convert.ToInt32(dr[1]),
                    klima = Convert.ToBoolean(dr[2]),
                    sauna = Convert.ToBoolean(dr[3]),
                    televizyon = Convert.ToBoolean(dr[4]),
                    manzaraId = Convert.ToInt32(dr[5]),
                    sacKurutmaMakinasi = Convert.ToBoolean(dr[6]),
                    jakuzi = Convert.ToBoolean(dr[7]),
                    sesYalitimi = Convert.ToBoolean(dr[8]),
                    mutfak = Convert.ToBoolean(dr[9]),
                    balkon = Convert.ToBoolean(dr[10])
                };
                result.Add(odaOzellik);
            }
            con.Close();
            return result;
        }

        public List<OdaOzellik> OdaOzellikSelectOdaTipID(OdaTip odaTip)
        {
            List<OdaOzellik> result = new List<OdaOzellik>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from OdaOzellik where TipID=@TipID", con);
            komut.Parameters.AddWithValue("@TipID", odaTip.id);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                OdaOzellik odaOzellik = new OdaOzellik(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    tipID = Convert.ToInt32(dr[1]),
                    klima = Convert.ToBoolean(dr[2]),
                    sauna = Convert.ToBoolean(dr[3]),
                    televizyon = Convert.ToBoolean(dr[4]),
                    manzaraId = Convert.ToInt32(dr[5]),
                    sacKurutmaMakinasi = Convert.ToBoolean(dr[6]),
                    jakuzi = Convert.ToBoolean(dr[7]),
                    sesYalitimi = Convert.ToBoolean(dr[8]),
                    mutfak = Convert.ToBoolean(dr[9]),
                    balkon = Convert.ToBoolean(dr[10])
                };
                result.Add(odaOzellik);
            }
            con.Close();
            return result;
        }
        #endregion

        #region OdaTip
        public int OdaTipInsert(OdaTip odaTipDegisken)
        {
            int result;
            con.Open();
            SqlCommand insert = new SqlCommand("insert into OdaTip(OtelID,Ad,Aciklama,Fiyat,OdaKapasite,resimAd)  output INSERTED.ID values(@OtelID,@Ad,@Aciklama,@Fiyat,@OdaKapasite,@resimAd)", con);
            insert.Parameters.AddWithValue("@OtelID", odaTipDegisken.otelID);
            insert.Parameters.AddWithValue("@Ad", odaTipDegisken.ad);
            insert.Parameters.AddWithValue("@Aciklama", odaTipDegisken.aciklama);
            insert.Parameters.AddWithValue("@Fiyat", odaTipDegisken.fiyat);
            insert.Parameters.AddWithValue("@OdaKapasite", odaTipDegisken.odaKapasite);
            insert.Parameters.AddWithValue("@resimAd", odaTipDegisken.resimAd);
            result = Convert.ToInt32(insert.ExecuteScalar());
            con.Close();
            return result;
        }

        public void OdaTipUpdate(OdaTip odaTipDegisken, string odaTipDegisecekAd)
        {
            SqlCommand update = new SqlCommand("update OdaTip set OtelID=@OtelID,Ad=@Ad,Aciklama=@Aciklama,Fiyat=@Fiyat,OdaKapasite=@OdaKapasite,resimAd=@resimAd where Ad=@DegisenAd", con);
            update.Parameters.AddWithValue("@OtelID", odaTipDegisken.otelID);
            update.Parameters.AddWithValue("@Ad", odaTipDegisken.ad);
            update.Parameters.AddWithValue("@Aciklama", odaTipDegisken.aciklama);
            update.Parameters.AddWithValue("@Fiyat", odaTipDegisken.fiyat);
            update.Parameters.AddWithValue("@OdaKapasite", odaTipDegisken.odaKapasite);
            update.Parameters.AddWithValue("@DegisenAd", odaTipDegisecekAd);
            update.Parameters.AddWithValue("@resimAd", odaTipDegisken.resimAd);
            KomutCalistir(update);
        }

        public void OdaTipDelete(OdaTip odaTipDegisken)
        {
            SqlCommand delete = new SqlCommand("delete from OdaTip where Ad=@Ad", con);
            delete.Parameters.AddWithValue("@Ad", odaTipDegisken.ad);
            KomutCalistir(delete);
        }

        public List<OdaTip> OdaTipSelect()
        {
            List<OdaTip> result = new List<OdaTip>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from OdaTip", con);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                OdaTip odaTip = new OdaTip(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    otelID = Convert.ToInt32(dr[1]),
                    ad = Convert.ToString(dr[2]),
                    aciklama = Convert.ToString(dr[3]),
                    fiyat = Convert.ToDouble(dr[4]),
                    odaKapasite = Convert.ToInt32(dr[5])
                };
                result.Add(odaTip);
            }
            con.Close();
            return result;
        }

        public List<OdaTip> OdaTipSelectOtelID(Oteller oteller )
        {
            List<OdaTip> result = new List<OdaTip>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from OdaTip where OtelID=@OtelID", con);
            komut.Parameters.AddWithValue("@OtelID", oteller.id);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                OdaTip odaTip = new OdaTip(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    otelID = Convert.ToInt32(dr[1]),
                    ad = Convert.ToString(dr[2]),
                    aciklama = Convert.ToString(dr[3]),
                    fiyat = Convert.ToDouble(dr[4]),
                    odaKapasite = Convert.ToInt32(dr[5])
                };
                result.Add(odaTip);
            }
            con.Close();
            return result;
        }

        public List<OdaTip> OdaTipSelectTipAd(OdaTip gelenOdaTip)
        {
            List<OdaTip> result = new List<OdaTip>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from OdaTip where Ad=@Ad", con);
            komut.Parameters.AddWithValue("@Ad", gelenOdaTip.ad);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                OdaTip odaTip = new OdaTip(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    otelID = Convert.ToInt32(dr[1]),
                    ad = Convert.ToString(dr[2]),
                    aciklama = Convert.ToString(dr[3]),
                    fiyat = Convert.ToDouble(dr[4]),
                    odaKapasite = Convert.ToInt32(dr[5]),
                    resimAd= Convert.ToString(dr[6])
                };
                result.Add(odaTip);
            }
            con.Close();
            return result;
        }

        public int OdaTipAyniAddaVarMiSelect(string tipAdi)
        {
            int result = 0;
            con.Open();
            SqlCommand komut = new SqlCommand("select Count(Ad) from OdaTip where Ad=@Ad", con);
            komut.Parameters.AddWithValue("@Ad", tipAdi);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                result=Convert.ToInt32(dr[0]);
            }
            con.Close();
            return result;
        }
        #endregion

        #region Oteller
        public void OtellerInsert(Oteller otellerDegisken)
        {
            SqlCommand insert = new SqlCommand("insert into Oteller(Ad,Adres,Fax,YildizSayisi) values(@Ad,@Adres,@Fax,@YildizSayisi)", con);
            insert.Parameters.AddWithValue("@Ad", otellerDegisken.ad);
            insert.Parameters.AddWithValue("@Adres", otellerDegisken.adres);
            insert.Parameters.AddWithValue("@Fax", otellerDegisken.fax);
            insert.Parameters.AddWithValue("@YildizSayisi", otellerDegisken.yildizSayisi);
            KomutCalistir(insert);
        }

        public void OtellerUpdate(Oteller otellerDegisken)
        {
            SqlCommand update = new SqlCommand("update Oteller set Ad=@Ad,Adres=@Adres,Fax=@Fax,YildizSayisi=@YildizSayisi where ID=@ID", con);
            update.Parameters.AddWithValue("@Ad", otellerDegisken.ad);
            update.Parameters.AddWithValue("@Adres", otellerDegisken.adres);
            update.Parameters.AddWithValue("@Fax", otellerDegisken.fax);
            update.Parameters.AddWithValue("@YildizSayisi", otellerDegisken.yildizSayisi);
            update.Parameters.AddWithValue("@ID", otellerDegisken.id);
            KomutCalistir(update);
        }

        public void OtellerDelete(Oteller otellerDegisken)
        {
            SqlCommand delete = new SqlCommand("delete from Oteller where ID=@ID", con);
            delete.Parameters.AddWithValue("@ID", otellerDegisken.id);
            KomutCalistir(delete);
        }

        public List<Oteller> OtellerSelect()
        {
            List<Oteller> result = new List<Oteller>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Oteller", con);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Oteller oteller = new Oteller()
                {

                    id = Convert.ToInt32(dr[0]),
                    ad = Convert.ToString(dr[1]),
                    adres = Convert.ToString(dr[2]),
                    fax = Convert.ToString(dr[3]),
                    yildizSayisi = Convert.ToInt32(dr[4])
                };
                result.Add(oteller);
            }
            con.Close();
            return result;
        }

        public int otelIDBul(Oteller oteller)
        {
            int id = 0;

            SqlCommand bul = new SqlCommand("select ID from Oteller where Ad=@Ad", con);
            bul.Parameters.AddWithValue("@Ad", oteller.ad);
            con.Open();
            SqlDataReader dr = bul.ExecuteReader();
            while (dr.Read())
            {
                id = Convert.ToInt32(dr[0].ToString());
            }
            con.Close();
            return id;

        }
        #endregion

        #region AnlaşmalıŞirketler
        public void AnlasmaliSirketlerInsert(AnlasmaliSirketler anlasmaliSirketlerDegisken)
        {
            SqlCommand insert = new SqlCommand("insert into AnlasmaliSirketler(Ad,Adres,Telefon,IndirimYuzdesi,SirketKodu,OtelID) values(@Ad,@Adres,@Telefon,@IndirimYuzdesi,@SirketKodu,@OtelID)", con);
            insert.Parameters.AddWithValue("@Ad", anlasmaliSirketlerDegisken.ad);
            insert.Parameters.AddWithValue("@Adres", anlasmaliSirketlerDegisken.adres);
            insert.Parameters.AddWithValue("@Telefon", anlasmaliSirketlerDegisken.telefon);
            insert.Parameters.AddWithValue("@IndirimYuzdesi", anlasmaliSirketlerDegisken.indirimYuzdesi);
            insert.Parameters.AddWithValue("@SirketKodu", anlasmaliSirketlerDegisken.sirketKodu);
            insert.Parameters.AddWithValue("@OtelID", anlasmaliSirketlerDegisken.otelID);
            KomutCalistir(insert);
        }

        public void AnlasmaliSirketlerUpdate(AnlasmaliSirketler anlasmaliSirketlerDegisken)
        {
            SqlCommand update = new SqlCommand("update AnlasmaliSirketler set Ad=@Ad,Adres=@Adres,Telefon=@Telefon,IndirimYuzdesi=@IndirimYuzdesi,SirketKodu=@SirketKodu,OtelID=@OtelID where ID=@ID", con);
            update.Parameters.AddWithValue("@Ad", anlasmaliSirketlerDegisken.ad);
            update.Parameters.AddWithValue("@Adres", anlasmaliSirketlerDegisken.adres);
            update.Parameters.AddWithValue("@Telefon", anlasmaliSirketlerDegisken.telefon);
            update.Parameters.AddWithValue("@IndirimYuzdesi", anlasmaliSirketlerDegisken.indirimYuzdesi);
            update.Parameters.AddWithValue("@SirketKodu", anlasmaliSirketlerDegisken.sirketKodu);
            update.Parameters.AddWithValue("@OtelID", anlasmaliSirketlerDegisken.otelID);
            update.Parameters.AddWithValue("@ID", anlasmaliSirketlerDegisken.id);
            KomutCalistir(update);
        }

        public void AnlasmaliSirketlerDelete(AnlasmaliSirketler anlasmaliSirketlerDegisken)
        {
            Oteller oteller = new Oteller();
            SqlCommand cmd = new SqlCommand("select ID from AnlasmaliSirketler where Ad=@Ad", con);
            cmd.Parameters.AddWithValue("@Ad", anlasmaliSirketlerDegisken.ad);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())

            {
                AnlasmaliSirketler anlasmaliSirketler = new AnlasmaliSirketler(oteller)
                {
                    id = int.Parse(dr[0].ToString())
                };

                con.Close();
                SqlCommand delete = new SqlCommand("delete from AnlasmaliSirketler where ID=@ID", con);
                delete.Parameters.AddWithValue("@ID", anlasmaliSirketler.id);
                KomutCalistir(delete);
            }


        }

        public List<AnlasmaliSirketler> AnlasmaliSirketlerSelect()
        {
            List<AnlasmaliSirketler> result = new List<AnlasmaliSirketler>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from AnlasmaliSirketler", con);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                AnlasmaliSirketler anlasmaliSirketler = new AnlasmaliSirketler(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    ad = Convert.ToString(dr[1]),
                    adres = Convert.ToString(dr[2]),
                    telefon = Convert.ToString(dr[3]),
                    indirimYuzdesi = Convert.ToInt32(dr[4]),
                    sirketKodu = Convert.ToString(dr[5]),
                    otelID = Convert.ToInt32(dr[6])
                };
                result.Add(anlasmaliSirketler);
            }
            con.Close();
            return result;
        }

        public AnlasmaliSirketler SirketKodunaGoreIndirimSelect(AnlasmaliSirketler anlasmaliSirketGetir)
        {
            AnlasmaliSirketler result = new AnlasmaliSirketler(null);
            con.Open();
            SqlCommand komut = new SqlCommand("select * from AnlasmaliSirketler where SirketKodu=@SirketKodu", con);
            komut.Parameters.AddWithValue("@SirketKodu",anlasmaliSirketGetir.sirketKodu);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                result = new AnlasmaliSirketler(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    ad = Convert.ToString(dr[1]),
                    adres = Convert.ToString(dr[2]),
                    telefon = Convert.ToString(dr[3]),
                    indirimYuzdesi = Convert.ToInt32(dr[4]),
                    sirketKodu = Convert.ToString(dr[5]),
                    otelID = Convert.ToInt32(dr[6])
                };
            }
            con.Close();
            return result;
        }
        #endregion

        #region OtelÖzellik
        public void OtelOzellikInsert(OtelOzellik otelOzellikDegisken)
        {
            SqlCommand insert = new SqlCommand("insert into OtelOzellik(OtelID,Fitness,InternetErisimi,OdaServisi,Restoran,YuzmeHavuzu,SaglikMerkezi,CocukTesisleri,Otopark,ToplantiOdasi,EvcilHayvan,Bar,HavaalaniServisi,AcikBufeKahvalti) values(@OtelID,@Fitness,@InternetErisimi,@OdaServisi,@Restoran,@YuzmeHavuzu,@SaglikMerkezi,@CocukTesisleri,@Otopark,@ToplantiOdasi,@EvcilHayvan,@Bar,@HavaalaniServisi,@AcikBufeKahvalti)", con);
            insert.Parameters.AddWithValue("@OtelID", otelOzellikDegisken.otelID);
            insert.Parameters.AddWithValue("@Fitness", otelOzellikDegisken.fitness);
            insert.Parameters.AddWithValue("@InternetErisimi", otelOzellikDegisken.internetErisimi);
            insert.Parameters.AddWithValue("@OdaServisi", otelOzellikDegisken.odaServisi);
            insert.Parameters.AddWithValue("@Restoran", otelOzellikDegisken.restoran);
            insert.Parameters.AddWithValue("@YuzmeHavuzu", otelOzellikDegisken.yuzmeHavuzu);
            insert.Parameters.AddWithValue("@SaglikMerkezi", otelOzellikDegisken.saglikMerkezi);
            insert.Parameters.AddWithValue("@CocukTesisleri", otelOzellikDegisken.cocukTesisleri);
            insert.Parameters.AddWithValue("@Otopark", otelOzellikDegisken.otopark);
            insert.Parameters.AddWithValue("@ToplantiOdasi", otelOzellikDegisken.toplantiOdasi);
            insert.Parameters.AddWithValue("@EvcilHayvan", otelOzellikDegisken.evcilHayvan);
            insert.Parameters.AddWithValue("@Bar", otelOzellikDegisken.bar);
            insert.Parameters.AddWithValue("@HavaalaniServisi", otelOzellikDegisken.havaalaniServisi);
            insert.Parameters.AddWithValue("@AcikBufeKahvalti", otelOzellikDegisken.acikBufeKahvalti);
            KomutCalistir(insert);
        }

        public void OtelOzellikUpdate(OtelOzellik otelOzellikDegisken)
        {
            SqlCommand update = new SqlCommand("update OtelOzellik set Fitness=@Fitness,InternetErisimi=@InternetErisimi,OdaServisi=@OdaServisi,Restoran=@Restoran,YuzmeHavuzu=@YuzmeHavuzu,SaglikMerkezi=@SaglikMerkezi,CocukTesisleri=@CocukTesisleri,Otopark=@Otopark,ToplantiOdasi=@ToplantiOdasi,EvcilHayvan=@EvcilHayvan,Bar=@Bar,HavaalaniServisi=@HavaalaniServisi,AcikBufeKahvalti=@AcikBufeKahvalti where OtelID=@OtelID", con);
            update.Parameters.AddWithValue("@Fitness", otelOzellikDegisken.fitness);
            update.Parameters.AddWithValue("@InternetErisimi", otelOzellikDegisken.internetErisimi);
            update.Parameters.AddWithValue("@OdaServisi", otelOzellikDegisken.odaServisi);
            update.Parameters.AddWithValue("@Restoran", otelOzellikDegisken.restoran);
            update.Parameters.AddWithValue("@YuzmeHavuzu", otelOzellikDegisken.yuzmeHavuzu);
            update.Parameters.AddWithValue("@SaglikMerkezi", otelOzellikDegisken.saglikMerkezi);
            update.Parameters.AddWithValue("@CocukTesisleri", otelOzellikDegisken.cocukTesisleri);
            update.Parameters.AddWithValue("@Otopark", otelOzellikDegisken.otopark);
            update.Parameters.AddWithValue("@ToplantiOdasi", otelOzellikDegisken.toplantiOdasi);
            update.Parameters.AddWithValue("@EvcilHayvan", otelOzellikDegisken.evcilHayvan);
            update.Parameters.AddWithValue("@Bar", otelOzellikDegisken.bar);
            update.Parameters.AddWithValue("@HavaalaniServisi", otelOzellikDegisken.havaalaniServisi);
            update.Parameters.AddWithValue("@AcikBufeKahvalti", otelOzellikDegisken.acikBufeKahvalti);
            update.Parameters.AddWithValue("@OtelID", otelOzellikDegisken.otelID);
            KomutCalistir(update);
        }

        public void OtelOzellikDelete(OtelOzellik otelOzellikDegisken)
        {
            SqlCommand delete = new SqlCommand("delete from OtelOzellik where ID=@ID", con);
            delete.Parameters.AddWithValue("@ID", otelOzellikDegisken.id);
            KomutCalistir(delete);
        }

        public List<OtelOzellik> OtelOzellikSelect()
        {
            List<OtelOzellik> result = new List<OtelOzellik>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from OtelOzellik", con);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                OtelOzellik otelOzellik = new OtelOzellik(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    otelID = Convert.ToInt32(dr[1]),
                    fitness = Convert.ToBoolean(dr[2]),
                    internetErisimi = Convert.ToBoolean(dr[3]),
                    odaServisi = Convert.ToBoolean(dr[4]),
                    restoran = Convert.ToBoolean(dr[5]),
                    yuzmeHavuzu = Convert.ToBoolean(dr[6]),
                    saglikMerkezi = Convert.ToBoolean(dr[7]),
                    cocukTesisleri = Convert.ToBoolean(dr[8]),
                    otopark = Convert.ToBoolean(dr[9]),
                    toplantiOdasi = Convert.ToBoolean(dr[10]),
                    evcilHayvan = Convert.ToBoolean(dr[11]),
                    bar = Convert.ToBoolean(dr[12]),
                    havaalaniServisi = Convert.ToBoolean(dr[13]),
                    acikBufeKahvalti = Convert.ToBoolean(dr[14])
                };
                result.Add(otelOzellik);
            }
            con.Close();
            return result;
        }
        #endregion

        #region Kullanıcılar
        public void KullanicilarInsert(Kullanicilar kullanicilarDegisken)
        {
            SqlCommand insert = new SqlCommand("insert into Kullanicilar(OtelID,KullaniciAd,Sifre,Ad,Soyad,Yetki) values(@OtelID,@KullaniciAd,@Sifre,@Ad,@Soyad,@Yetki)", con);
            insert.Parameters.AddWithValue("@OtelID", kullanicilarDegisken.otelID);
            insert.Parameters.AddWithValue("@KullaniciAd", kullanicilarDegisken.kullaniciAd);
            insert.Parameters.AddWithValue("@Sifre", kullanicilarDegisken.sifre);
            insert.Parameters.AddWithValue("@Ad", kullanicilarDegisken.ad);
            insert.Parameters.AddWithValue("@Soyad", kullanicilarDegisken.soyad);
            insert.Parameters.AddWithValue("@Yetki", kullanicilarDegisken.yetki);
            KomutCalistir(insert);
        }

        public void KullanicilarUpdate(Kullanicilar kullanicilarDegisken)
        {
            SqlCommand update = new SqlCommand("update Kullanicilar set OtelID=@OtelID,KullaniciAd=@KullaniciAd,Sifre=@Sifre,Ad=@Ad,Soyad=@Soyad,Yetki=@Yetki where ID=@ID", con);
            update.Parameters.AddWithValue("@OtelID", kullanicilarDegisken.otelID);
            update.Parameters.AddWithValue("@KullaniciAd", kullanicilarDegisken.kullaniciAd);
            update.Parameters.AddWithValue("@Sifre", kullanicilarDegisken.sifre);
            update.Parameters.AddWithValue("@Ad", kullanicilarDegisken.ad);
            update.Parameters.AddWithValue("@Soyad", kullanicilarDegisken.soyad);
            update.Parameters.AddWithValue("@Yetki", kullanicilarDegisken.yetki);
            update.Parameters.AddWithValue("@ID", kullanicilarDegisken.id);
            KomutCalistir(update);
        }

        public void KullanicilarDelete(Kullanicilar kullanicilarDegisken)
        {
            SqlCommand delete = new SqlCommand("delete from Kullanicilar where ID=@ID", con);
            delete.Parameters.AddWithValue("@ID", kullanicilarDegisken.id);
            KomutCalistir(delete);
        }

        public List<Kullanicilar> KullanicilarSelect(Kullanicilar kullanici)
        {
            List<Kullanicilar> result = new List<Kullanicilar>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Kullanicilar where KullaniciAd=@kad and Sifre=@sifre", con);
            komut.Parameters.AddWithValue("@kad", kullanici.kullaniciAd);
            komut.Parameters.AddWithValue("@sifre", kullanici.sifre);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Kullanicilar kullanicilar = new Kullanicilar(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    otelID = Convert.ToInt32(dr[1]),
                    kullaniciAd = Convert.ToString(dr[2]),
                    sifre = Convert.ToString(dr[3]),
                    ad = Convert.ToString(dr[4]),
                    soyad = Convert.ToString(dr[5]),
                    yetki = Convert.ToBoolean(dr[6])
                };
                result.Add(kullanicilar);
            }
            con.Close();
            return result;
        }
        #endregion

        #region Konaklamalar
        public void KonaklamalarInsert(Konaklamalar konaklamalarDegisken)
        {
            SqlCommand insert = new SqlCommand("insert into Konaklamalar(OtelID,TcKimlik,Ad,Soyad,TelefonNo,OdaNo,Kat,GelisTarihi,GidisTarihi,IndirimOrani,Ucret) values(@OtelID,@TcKimlik,@Ad,@Soyad,@TelefonNo,@OdaNo,@Kat,@GelisTarihi,@GidisTarihi,@IndirimOrani,@Ucret)", con);
            insert.Parameters.AddWithValue("@OtelID", konaklamalarDegisken.otelID);
            insert.Parameters.AddWithValue("@TcKimlik", konaklamalarDegisken.tcKimlik);
            insert.Parameters.AddWithValue("@Ad", konaklamalarDegisken.ad);
            insert.Parameters.AddWithValue("@Soyad", konaklamalarDegisken.soyad);
            insert.Parameters.AddWithValue("@TelefonNo", konaklamalarDegisken.telefonNo);
            insert.Parameters.AddWithValue("@OdaNo", konaklamalarDegisken.odaNo);
            insert.Parameters.AddWithValue("@Kat", konaklamalarDegisken.kat);
            insert.Parameters.AddWithValue("@GelisTarihi", konaklamalarDegisken.gelisTarihi);
            insert.Parameters.AddWithValue("@GidisTarihi", konaklamalarDegisken.gidisTarihi);
            insert.Parameters.AddWithValue("@IndirimOrani", konaklamalarDegisken.indirimOrani);
            insert.Parameters.AddWithValue("@Ucret", konaklamalarDegisken.Ucret);
            KomutCalistir(insert);
        }

        //22.08.2019 19:33 sadece fiyat güncellemesi yapılacağı için böyle kullandım.
        public void KonaklamalarUpdate(Konaklamalar konaklamalarDegisken)
        {
            SqlCommand update = new SqlCommand("update Konaklamalar set Ucret=@OdenenMiktar where OdaNo=@OdaNo and isActive=1", con);
            //update.Parameters.AddWithValue("@OtelID", konaklamalarDegisken.otelID);
            update.Parameters.AddWithValue("@OdaNo", konaklamalarDegisken.odaNo);
            //update.Parameters.AddWithValue("@Ad", konaklamalarDegisken.ad);
            //update.Parameters.AddWithValue("@Soyad", konaklamalarDegisken.soyad);
            //update.Parameters.AddWithValue("@TelefonNo", konaklamalarDegisken.telefonNo);
            //update.Parameters.AddWithValue("@OdaNo", konaklamalarDegisken.odaNo);
            //update.Parameters.AddWithValue("@Kat", konaklamalarDegisken.kat);
            //update.Parameters.AddWithValue("@GelisTarihi", konaklamalarDegisken.gelisTarihi);
            //update.Parameters.AddWithValue("@GidisTarihi", konaklamalarDegisken.gidisTarihi);
            //update.Parameters.AddWithValue("@IndirimOrani", konaklamalarDegisken.indirimOrani);
            update.Parameters.AddWithValue("@OdenenMiktar", konaklamalarDegisken.alinanUcret);
            //update.Parameters.AddWithValue("@ID", konaklamalarDegisken.id);
            KomutCalistir(update);
        }
        //22.08.2019 19:33 sadece fiyat güncellemesi yapılacağı için böyle kullandım.


        public void KonaklamalarDelete(Konaklamalar konaklamalarDegisken)
        {
            SqlCommand delete = new SqlCommand("update Konaklamalar set IsActive=0 where TcKimlik=@TcKimlik", con);
            delete.Parameters.AddWithValue("@TcKimlik", konaklamalarDegisken.tcKimlik);
            KomutCalistir(delete);
        }

        public List<Konaklamalar> KonaklamalarSelect(Konaklamalar arananKonaklamalar)
        {
            List<Konaklamalar> result = new List<Konaklamalar>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Konaklamalar where Ad like  @ad + '%' and IsActive=1", con);
            komut.Parameters.AddWithValue("@ad", arananKonaklamalar.ad);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Konaklamalar konaklamalar = new Konaklamalar(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    otelID = Convert.ToInt32(dr[1]),
                    tcKimlik = Convert.ToString(dr[2]),
                    ad = Convert.ToString(dr[3]),
                    soyad = Convert.ToString(dr[4]),
                    telefonNo = Convert.ToString(dr[5]),
                    odaNo = Convert.ToInt32(dr[6]),
                    kat = Convert.ToInt32(dr[7]),
                    gelisTarihi = Convert.ToDateTime(dr[8]),
                    gidisTarihi = Convert.ToDateTime(dr[9])
                };
                result.Add(konaklamalar);
            }
            con.Close();
            return result;
        }

        public List<Konaklamalar> odaBulunanKonaklamalarSelect(int odaNo)
        {
            List<Konaklamalar> result = new List<Konaklamalar>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Konaklamalar where OdaNo=@OdaNo and IsActive=1", con);
            komut.Parameters.AddWithValue("@OdaNo", odaNo);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Konaklamalar konaklamalar = new Konaklamalar(null)
                {
                    tcKimlik = Convert.ToString(dr[2].ToString()),
                    ad = Convert.ToString(dr[3]),
                    soyad = Convert.ToString(dr[4]),
                    telefonNo= Convert.ToString(dr[5]),
                    odaNo = Convert.ToInt32(dr[6]),
                    gelisTarihi = Convert.ToDateTime(dr[8]),
                    gidisTarihi = Convert.ToDateTime(dr[9])
                };
                result.Add(konaklamalar);
            }
            con.Close();
            return result;
        }

        public List<Konaklamalar> KonaklamalarKimlikNoSelect(Konaklamalar arananKonaklamalar)
        {
            List<Konaklamalar> result = new List<Konaklamalar>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Konaklamalar where TcKimlik=@Tc and IsActive=1", con);
            komut.Parameters.AddWithValue("@Tc",arananKonaklamalar.tcKimlik);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Konaklamalar konaklamalar = new Konaklamalar(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    otelID = Convert.ToInt32(dr[1]),
                    tcKimlik = Convert.ToString(dr[2]),
                    ad = Convert.ToString(dr[3]),
                    soyad = Convert.ToString(dr[4]),
                    telefonNo = Convert.ToString(dr[5]),
                    odaNo = Convert.ToInt32(dr[6]),
                    kat = Convert.ToInt32(dr[7]),
                    gelisTarihi = Convert.ToDateTime(dr[8]),
                    gidisTarihi = Convert.ToDateTime(dr[9])
                };
                result.Add(konaklamalar);
            }
            con.Close();
            return result;
        }

        //tc ye göre veri checkout
        public List<Konaklamalar> odaBulunanKonaklamalarSelectCheckOut(Konaklamalar konaklama)
        {
            List<Konaklamalar> result = new List<Konaklamalar>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Konaklamalar where TcKimlik=@tc and IsActive=1", con);
            komut.Parameters.AddWithValue("@tc", konaklama.tcKimlik);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Konaklamalar konaklamalar = new Konaklamalar(null)
                {
                    tcKimlik = Convert.ToString(dr[2].ToString()),
                    ad = Convert.ToString(dr[3]),
                    soyad = Convert.ToString(dr[4]),
                    telefonNo = Convert.ToString(dr[5]),
                    odaNo = Convert.ToInt32(dr[6]),
                    gelisTarihi = Convert.ToDateTime(dr[8]),
                    gidisTarihi = Convert.ToDateTime(dr[9]),
                    Ucret = Convert.ToDouble(dr[11])
                };
                result.Add(konaklamalar);
            }
            con.Close();
            return result;
        }
        //tc ye göre veri checkout
        //odada kalan diğer kişiler 23.08.2019 09.35
        public List<Konaklamalar> odadaBulunanDigerKisileriGetir(Konaklamalar konaklama)
        {
            List<Konaklamalar> result = new List<Konaklamalar>();
            con.Open();
            SqlCommand komut = new SqlCommand("Select * from Konaklamalar where OdaNo=@odaNo and TcKimlik<>@tc and IsActive=1", con);
            komut.Parameters.AddWithValue("@tc", konaklama.tcKimlik);
            komut.Parameters.AddWithValue("@odaNo", konaklama.odaNo);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Konaklamalar konaklamalar = new Konaklamalar(null)
                {
                    tcKimlik = Convert.ToString(dr[2].ToString()),
                    ad = Convert.ToString(dr[3]),
                    soyad = Convert.ToString(dr[4]),
                    telefonNo = Convert.ToString(dr[5]),
                    odaNo = Convert.ToInt32(dr[6]),
                    gelisTarihi = Convert.ToDateTime(dr[8]),
                    gidisTarihi = Convert.ToDateTime(dr[9]),
                    Ucret = Convert.ToDouble(dr[11])
                };
                result.Add(konaklamalar);
            }
            con.Close();
            return result;
        }
        //odada kalan diğer kişiler 23.08.2019 09.35

        //odada kalan diğer kişiler 23.08.2019 15,15
        public List<Konaklamalar> odadaBulunanDigerKisileriGetir2(int odaNo, string tcKimlik)
        {
            List<Konaklamalar> result = new List<Konaklamalar>();
            con.Open();
            SqlCommand komut = new SqlCommand("Select * from Konaklamalar where OdaNo=@odaNo and TcKimlik<>@tc and IsActive=1", con);
            komut.Parameters.AddWithValue("@tc", tcKimlik);
            komut.Parameters.AddWithValue("@odaNo", odaNo);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Konaklamalar konaklamalar = new Konaklamalar(null)
                {
                    tcKimlik = Convert.ToString(dr[2].ToString()),
                    ad = Convert.ToString(dr[3]),
                    soyad = Convert.ToString(dr[4]),
                    telefonNo = Convert.ToString(dr[5]),
                    odaNo = Convert.ToInt32(dr[6]),
                    gelisTarihi = Convert.ToDateTime(dr[8]),
                    gidisTarihi = Convert.ToDateTime(dr[9]),
                    Ucret = Convert.ToDouble(dr[11])
                };
                result.Add(konaklamalar);
            }
            con.Close();
            return result;
        }
        //odada kalan diğer kişiler 23.08.2019 15,15
        //22.08.2019 bugünCikisYapacaklar eklendi
        public List<Konaklamalar> bugunCikisYapacaklar(Konaklamalar konaklama)
        {
            List<Konaklamalar> result = new List<Konaklamalar>();
            con.Open();
            SqlCommand komut = new SqlCommand("SELECT TcKimlik, Ad, Soyad, TelefonNo, OdaNo, GelisTarihi, GidisTarihi FROM dbo.Konaklamalar WHERE (IsActive = 1 and GidisTarihi='" + konaklama.gidisTarihi.Date.ToString("yyyy-MM-dd") + "')", con);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Konaklamalar konaklamalar = new Konaklamalar(null)
                {
                    tcKimlik = Convert.ToString(dr[0].ToString()),
                    ad = Convert.ToString(dr[1]),
                    soyad = Convert.ToString(dr[2]),
                    telefonNo = Convert.ToString(dr[3]),
                    odaNo = Convert.ToInt32(dr[4]),
                    gelisTarihi = Convert.ToDateTime(dr[5]),
                    gidisTarihi = Convert.ToDateTime(dr[6])
                };
                result.Add(konaklamalar);
            }
            con.Close();
            return result;
        }
        //22.08.2019 Bugün Konaklayan eklendi
        //23.08.2019 14.50
        public List<Konaklamalar> ucretAlindiktanSonraKisiBilgi(Konaklamalar konaklama)
        {
            List<Konaklamalar> result = new List<Konaklamalar>();
            con.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Konaklamalar where TcKimlik=@tc", con);
            komut.Parameters.AddWithValue("@tc", konaklama.tcKimlik);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Konaklamalar konaklamalar = new Konaklamalar(null)
                {
                    tcKimlik = Convert.ToString(dr[2].ToString()),
                    ad = Convert.ToString(dr[3]),
                    soyad = Convert.ToString(dr[4]),
                    telefonNo = Convert.ToString(dr[5]),
                    odaNo = Convert.ToInt32(dr[6]),
                    gelisTarihi = Convert.ToDateTime(dr[8]),
                    gidisTarihi = Convert.ToDateTime(dr[9]),
                    Ucret = Convert.ToDouble(dr[11])
                };
                result.Add(konaklamalar);
            }
            con.Close();
            return result;
        }
        //23.08.2019 14.50
        #endregion

        #region Admin
        public void AdminInsert(Admin adminDegisken)
        {
            SqlCommand insert = new SqlCommand("insert into Admin(KullaniciAd,Sifre) values(@KullaniciAd,@Sifre)", con);
            insert.Parameters.AddWithValue("@KullaniciAd", adminDegisken.kullaniciAd);
            insert.Parameters.AddWithValue("@Sifre", adminDegisken.sifre);
            KomutCalistir(insert);
        }

        public void AdminDelete(Admin adminDegisken)
        {
            SqlCommand delete = new SqlCommand("delete from Admin where KullaniciAd=@KullaniciAd", con);
            delete.Parameters.AddWithValue("@KullaniciAd", adminDegisken.kullaniciAd);
            KomutCalistir(delete);
        }

        public List<Admin> AdminSelect(Admin adminGetir)
        {
            List<Admin> result = new List<Admin>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Admin where KullaniciAd=@kad and Sifre=@sifre", con);
            komut.Parameters.AddWithValue("@kad", adminGetir.kullaniciAd);
            komut.Parameters.AddWithValue("@sifre", adminGetir.sifre);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Admin admin = new Admin()
                {
                    kullaniciAd = Convert.ToString(dr[0]),
                    sifre = Convert.ToString(dr[1])
                };
                result.Add(admin);
            }
            con.Close();
            return result;
        }
        #endregion

        #region DolulukTakvimi

        public void DolulukTakvimiInsert(DolulukTakvimi dolulukTakvimiDegisken)
        {
            SqlCommand insert = new SqlCommand("insert into DolulukTakvimi(OdaID,DoluTarih) values(@OdaID,@DoluTarih)", con);
            insert.Parameters.AddWithValue("@OdaID", dolulukTakvimiDegisken.odaID);
            insert.Parameters.AddWithValue("@DoluTarih", dolulukTakvimiDegisken.doluTarih);
            KomutCalistir(insert);
        }

        public void DolulukTakvimiDelete(DolulukTakvimi dolulukTakvimiDegisken,DateTime silmeyeBaslananTarih,DateTime sonSilinenTarih)
        {
            SqlCommand delete = new SqlCommand("delete from DolulukTakvimi where OdaID=@OdaID and (DoluTarih>=@SilmeyeBaslananTarih and DoluTarih<=@SonSilinenTarih)", con);
            delete.Parameters.AddWithValue("@OdaID", dolulukTakvimiDegisken.odaID);
            delete.Parameters.AddWithValue("SilmeyeBaslananTarih",silmeyeBaslananTarih);
            delete.Parameters.AddWithValue("SonSilinenTarih", sonSilinenTarih);
            KomutCalistir(delete);
        }

        public List<DolulukTakvimi> DolulukTakvimiSelect()
        {
            List<DolulukTakvimi> result = new List<DolulukTakvimi>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from DolulukTakvimi", con);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                DolulukTakvimi dolulukTakvimi = new DolulukTakvimi()
                {

                    odaID = Convert.ToInt32(dr[0]),
                    doluTarih = Convert.ToDateTime(dr[1])
                };
                result.Add(dolulukTakvimi);
            }
            con.Close();
            return result;
        }

        #endregion

        public int odaTipIDBul(OdaTip odaTip)
        {
            int id = 0;

            SqlCommand bul = new SqlCommand("select ID from OdaTip where Ad=@Ad", con);
            bul.Parameters.AddWithValue("@Ad", odaTip.ad);
            con.Open();
            SqlDataReader dr = bul.ExecuteReader();
            while (dr.Read())
            {
                id = Convert.ToInt32(dr[0].ToString());
            }
            con.Close();
            return id;

        }

        public List<Odalar> katGetir()///oda düzenle bölümünde kat selecti
        {
            Oteller oteller = new Oteller();
            OdaTip odaTip = new OdaTip(oteller);

            List<Odalar> result = new List<Odalar>();
            SqlCommand cmd = new SqlCommand("select distinct(kat) from odalar", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                Odalar odalar = new Odalar(oteller, odaTip)
                {
                    kat = Convert.ToInt32(dr[0])

                };

                result.Add(odalar);

            }
            con.Close();
            dr.Close();
            return result;
        }

        public List<Odalar> kataGoreOdalarGetir(Odalar odalar)//katagore oda getirecek
        {
            List<Odalar> result = new List<Odalar>();
            Oteller oteller = new Oteller();
            OdaTip odaTip = new OdaTip(oteller);
            SqlCommand cmd = new SqlCommand("select OdaNo from Odalar where kat=@kat", con);
            cmd.Parameters.AddWithValue("@kat", odalar.kat);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())

            {
                Odalar odalarr = new Odalar(oteller, odaTip);
                {
                    odalarr.odaNo = Convert.ToInt16(dr[0].ToString());

                };
                result.Add(odalarr);

            }
            dr.Close();
            con.Close();
            return result;
        }

        public List<OdaTip> tipAdlari(OdaTip odaTip)
        {
            List<OdaTip> result = new List<OdaTip>();
            Oteller oteller = new Oteller();
            SqlCommand TipAdlariniGetir = new SqlCommand("select Ad From OdaTip ", con);
            con.Open();
            SqlDataReader dr = TipAdlariniGetir.ExecuteReader();

            while (dr.Read())
            {
                OdaTip odaTipdegisken = new OdaTip(oteller)
                {
                    ad = dr[0].ToString()

                };
                result.Add(odaTipdegisken);

            }

            con.Close();
            dr.Close();
            return result;
        }

        public List<OdaTip> tipAdAra(Odalar odalardegisken)// seçilen odanın tip Adını getirdim
        {
            Oteller oteller = new Oteller();

            Odalar odalar = new Odalar(oteller, null);
            List<OdaTip> result = new List<OdaTip>();
            SqlCommand tipIDBul = new SqlCommand("select TipID from Odalar where OdaNo=@OdaNo", con);
            tipIDBul.Parameters.AddWithValue("@OdaNo", odalardegisken.odaNo);
            con.Open();
            int TipID = 0;
            SqlDataReader dr = tipIDBul.ExecuteReader();
            if (dr.Read())
            {
                TipID = Convert.ToInt32(dr[0]);
            }
            dr.Close();


            SqlCommand tipAdBul = new SqlCommand("select Ad,Aciklama from OdaTip where ID=@TipID", con);
            tipAdBul.Parameters.AddWithValue("@TipID", TipID);
            SqlDataReader dr2 = tipAdBul.ExecuteReader();
            if (dr2.Read())
            {
                OdaTip odaTipdegisken = new OdaTip(oteller)
                {
                    ad = dr2[0].ToString(),
                    aciklama = dr2[1].ToString()


                };

                result.Add(odaTipdegisken);
            }
            con.Close();

            return result;
        }

        public List<OdaTip> aciklamaAra(OdaTip odaTip)
        {
            Oteller oteller = new Oteller();
            List<OdaTip> result = new List<OdaTip>();
            SqlCommand cmd = new SqlCommand("Select Aciklama from OdaTip where Ad=@Ad", con);
            cmd.Parameters.AddWithValue("@Ad", odaTip.ad);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                OdaTip odaTipDegisken = new OdaTip(oteller)
                {
                    aciklama = dr[0].ToString()
                };

                result.Add(odaTipDegisken);
            }
            con.Close();
            return result;
        }

        public List<OdaTip> tipIDGetir(OdaTip odaTipDegisken)
        {
            Oteller oteller = new Oteller();
            List<OdaTip> result = new List<OdaTip>();
            SqlCommand cmd = new SqlCommand("select ID from OdaTip where Ad=@TipAd", con);
            cmd.Parameters.AddWithValue("@TipAd", odaTipDegisken.ad);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                OdaTip odaTip = new OdaTip(oteller)
                {
                    id = int.Parse(dr[0].ToString())

                };

                result.Add(odaTip);
            }
            con.Close();
            return result;

        }

        public List<Odalar> OdaDurumSelect(string arananOda)
        {
            List<Odalar> result = new List<Odalar>();
            con.Open();
            SqlCommand komut = new SqlCommand("select * from OdaDurum where OdaNo like @ArananOda + '%' Order BY OdaNo ASC", con);
            komut.Parameters.AddWithValue("@ArananOda", arananOda);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Odalar odalar = new Odalar(null, null)
                {
                    odaNo = Convert.ToInt32(dr[0]),
                    durum = dr[1].ToString()
                };
                result.Add(odalar);
            }
            con.Close();
            return result;
        }

        public List<OdaTip> OdaTipFiyatSelect(Odalar odalar)
        {
            List<OdaTip> result = new List<OdaTip>();
            con.Open();
            SqlCommand komut = new SqlCommand("select Fiyat from OdaTip where ID=@ID", con);
            komut.Parameters.AddWithValue("@ID", odalar.tipID);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                OdaTip odaTip = new OdaTip(null)
                {
                    fiyat = Convert.ToDouble(dr[0])
                };
                result.Add(odaTip);
            }
            con.Close();
            return result;
        }

        public OdaTip OdaTipKapasite()
        {
            OdaTip result = new OdaTip(null);
            con.Open();
            SqlCommand komut = new SqlCommand("select * from Kapasite", con);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                result.odaKapasite = Convert.ToInt32(dr[0]);
            }
            con.Close();
            return result;
        }

        public List<OdaOzellik> OdalarAnaSayfa(Rezervasyon rezervasyon,OdaTip odaKapasiteAra,string sqlSorgu)
        {
            List<OdaOzellik> result = new List<OdaOzellik>();            
            con.Open();
            SqlCommand komut = new SqlCommand(sqlSorgu, con);
            komut.Parameters.AddWithValue("@Kapasite", odaKapasiteAra.odaKapasite);
            komut.Parameters.AddWithValue("@GelisTarih",rezervasyon.gelisTarihi);
            komut.Parameters.AddWithValue("@GidisTarih",rezervasyon.gidisTarihi);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                OdaTip odaTip = new OdaTip(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    otelID = Convert.ToInt32(dr[1]),
                    ad = Convert.ToString(dr[2]),
                    aciklama = Convert.ToString(dr[3]),
                    fiyat = Convert.ToDouble(dr[4]),
                    odaKapasite = Convert.ToInt32(dr[5]),
                    resimAd= Convert.ToString(dr[6])
                };
                OdaOzellik odaOzellik = new OdaOzellik(odaTip)
                {

                    id = Convert.ToInt32(dr[7]),
                    tipID = Convert.ToInt32(dr[8]),
                    klima = Convert.ToBoolean(dr[9]),
                    sauna = Convert.ToBoolean(dr[10]),
                    televizyon = Convert.ToBoolean(dr[11]),
                    manzaraId = Convert.ToInt32(dr[12]),
                    sacKurutmaMakinasi = Convert.ToBoolean(dr[13]),
                    jakuzi = Convert.ToBoolean(dr[14]),
                    sesYalitimi = Convert.ToBoolean(dr[15]),
                    mutfak = Convert.ToBoolean(dr[16]),
                    balkon = Convert.ToBoolean(dr[17])
                };
                result.Add(odaOzellik);
            }
            con.Close();
            return result;
        }

        public List<Odalar> OdaMusaitlikDogrula(Rezervasyon rezervasyon, OdaTip odaKapasiteAra)
        {
            List<Odalar> result = new List<Odalar>();
            con.Open();
            SqlCommand komut = new SqlCommand(" select Top(1) * from OdaTip inner join Odalar on OdaTip.ID = Odalar.TipID where OdaKapasite >=@Kapasite and OdaTip.Ad=@OdaTipAd and Odalar.ID in (select ID from Odalar where ID not in (select OdaID from DolulukTakvimi, Odalar where(DolulukTakvimi.DoluTarih >=@GelisTarih and DolulukTakvimi.DoluTarih <=@GidisTarih)))", con);
            komut.Parameters.AddWithValue("@Kapasite", odaKapasiteAra.odaKapasite);
            komut.Parameters.AddWithValue("@GelisTarih", rezervasyon.gelisTarihi);
            komut.Parameters.AddWithValue("@GidisTarih", rezervasyon.gidisTarihi);
            komut.Parameters.AddWithValue("@OdaTipAd", odaKapasiteAra.ad);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                OdaTip odaTip = new OdaTip(null)
                {

                    id = Convert.ToInt32(dr[0]),
                    otelID = Convert.ToInt32(dr[1]),
                    ad = Convert.ToString(dr[2]),
                    aciklama = Convert.ToString(dr[3]),
                    fiyat = Convert.ToDouble(dr[4]),
                    odaKapasite = Convert.ToInt32(dr[5]),
                    resimAd = Convert.ToString(dr[6])
                };
                Odalar odalar = new Odalar(null, odaTip)
                {
                    id = Convert.ToInt32(dr[7]),
                    odaNo = Convert.ToInt32(dr[8]),
                    kat = Convert.ToInt32(dr[9]),
                    tipID = Convert.ToInt32(dr[10])
                };
                result.Add(odalar);
            }
            con.Close();
            return result;
        }

        #region Komutİşlemleri
        public Boolean KomutCalistir(SqlCommand komut)
        {
            con.Open();
            komut.ExecuteNonQuery();
            komut.Dispose();
            con.Close();
            return true;
        }
        #endregion

    }
}
