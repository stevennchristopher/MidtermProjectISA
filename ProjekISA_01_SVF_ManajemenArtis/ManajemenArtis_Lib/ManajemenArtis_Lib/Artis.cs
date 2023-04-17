﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ManajemenArtis_Lib
{
    public class Artis
    {
        public enum status_manajer
        {
            kosong,
            aktif
        }

        #region DATAMEMBER
        private int id;
        private string nama;
        private DateTime tanggal_lahir;
        private DateTime tanggal_masuk;
        private string username;
        private string password;
        private status_manajer status;
        #endregion

        #region CONSTRUCTOR
        public Artis()
        {
            this.Id = 0;
            this.Nama = "";
            this.Tanggal_lahir = DateTime.Now;
            this.Tanggal_masuk = DateTime.Now;
            this.Username = "";
            this.Password = "";
        }

        public Artis(int id, string nama, DateTime tanggal_lahir, DateTime tanggal_masuk, string username, string password, status_manajer status)
        {
            this.Id = id;
            this.Nama = nama;
            this.Tanggal_lahir = tanggal_lahir;
            this.Tanggal_masuk = tanggal_masuk;
            this.Username = username;
            this.Password = password;
            this.Status = status;
        }
        #endregion

        #region PROPERTIES
        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public DateTime Tanggal_lahir { get => tanggal_lahir; set => tanggal_lahir = value; }
        public DateTime Tanggal_masuk { get => tanggal_masuk; set => tanggal_masuk = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public status_manajer Status { get => status; set => status = value; }
        #endregion

        #region METHODS
        public static Artis CekLogin(string username, string password)
        {
            //Password tidak diambil karena tidak perlu menyimpan password pada obyek artis untuk alasan keamanan
            string sql = "SELECT id, nama, tanggal_lahir, tanggal_masuk, username, status_manajer " +
                " FROM artis " +
                " WHERE username='" + username + "' AND password='" + password + "';";

            MySqlDataReader result = Koneksi.JalankanQuery(sql);

            Artis tmp = new Artis();
            if (result.Read())
            {
                status_manajer tmpStatus = status_manajer.kosong;

                tmp = new Artis(
                    result.GetInt32("id"),
                    result.GetString("nama"),
                    result.GetDateTime("tanggal_lahir"),
                    result.GetDateTime("tanggal_masuk"),
                    result.GetString("username"),
                    "",
                    tmpStatus);

                return tmp;
            }
            return null;
        }
        #endregion
    }
}
