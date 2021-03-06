﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProjectDDS.DAO;

namespace ProjectDDS.GUI.ManHinhTuVanLapTop
{
    public partial class TuVanLapTop : DevExpress.XtraEditors.XtraForm
    {
        private List<String> listProducts = new List<string>();
        private List<String> listRam = new List<String>();
        private List<String> listHD = new List<String>();
        private string currentTenLaptop;


        public TuVanLapTop()
        {
            InitializeComponent();

            //Init combobox data
            listProducts.Add("RAM");
            listProducts.Add("HARD DISK");

            cbb_LinhKien.Properties.DataSource = listProducts;
            // This line of code is generated by Data Source Configuration Wizard
            edt_TenLaptop.Properties.DataSource = new ProjectDDS.DAO.QLCuaHangDDSDataContext().LAPTOPs;
        }

        private void cbb_LinhKien_EditValueChanged(object sender, EventArgs e)
        {
            switch (cbb_LinhKien.Text.ToString())
            {
                case "RAM":
                    gridControlResult.DataSource = null;
                    gridViewResult.Columns.Clear();
                    gridControlResult.DataSource = RamDAO.getListRamByLapTopId(this.currentTenLaptop);
                    gridControlResult.RefreshDataSource();
                    gridViewResult.Columns[0].Caption = "Tên RAM";
                    gridViewResult.Columns[1].Caption = "Giá (VNĐ)";
                    gridViewResult.Columns[2].Caption = "Hãng sản xuất";
                    gridViewResult.Columns[3].Visible = false;
                    gridViewResult.Columns[4].Visible = false;
                    gridViewResult.Columns[5].Caption = "Dung lượng (GB)";
                    gridViewResult.Columns[6].Visible = false;
                    gridViewResult.Columns[7].Visible = false;
                    gridViewResult.Columns[8].Visible = false;
                    break;
                case "HARD DISK":
                    gridControlResult.DataSource = null;
                    gridViewResult.Columns.Clear();
                    gridControlResult.DataSource = RamDAO.getListHDByLapTopId(this.currentTenLaptop);
                    gridControlResult.RefreshDataSource();
                    gridViewResult.Columns[0].Caption = "Tên HARD DISK";
                    gridViewResult.Columns[1].Visible = false;
                    gridViewResult.Columns[2].Caption = "Giá (VNĐ)";
                    gridViewResult.Columns[3].Caption = "Hãng sản xuất";
                    gridViewResult.Columns[4].Visible = false;
                    gridViewResult.Columns[5].Caption = "Dung lượng (GB)";
                    gridViewResult.Columns[6].Visible = false;
                    gridViewResult.Columns[7].Visible = false;
                    gridViewResult.Columns[8].Visible = false;
                    gridViewResult.Columns[9].Visible = false;
                    gridViewResult.Columns[10].Visible = false;
                    gridViewResult.Columns[11].Visible = false;
                    break;
            }
        }

        private void edt_TenLaptop_EditValueChanged(object sender, EventArgs e)
        {
            this.currentTenLaptop = edt_TenLaptop.Text.ToString();
            this.cbb_LinhKien_EditValueChanged(null, null);
        }

        private void edt_TenLaptop_Properties_Popup(object sender, EventArgs e)
        {
            LookUpEdit lookUpEdit = sender as LookUpEdit;
            if (lookUpEdit == null)
                return;

            edt_TenLaptop.Properties.Columns[0].Caption = "Tên laptop";
            edt_TenLaptop.Properties.Columns[1].Caption = "Hãng sản xuất";
            edt_TenLaptop.Properties.Columns[2].Caption = "Giá (VNĐ)";
            edt_TenLaptop.Properties.Columns[3].Visible = false;
            edt_TenLaptop.Properties.Columns[4].Visible = false;
            edt_TenLaptop.Properties.Columns[5].Visible = false;
            edt_TenLaptop.Properties.Columns[6].Visible = false;
            edt_TenLaptop.Properties.Columns[7].Visible = false;
            edt_TenLaptop.Properties.Columns[8].Visible = false;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            switch (cbb_LinhKien.Text.ToString())
            {
                case "RAM":
                    listRam.Add(gridViewResult.GetFocusedRowCellValue("Ten").ToString());
                    listRam = listRam.Distinct().ToList();
                    listBoxControlRAM.DataSource = listRam;
                    listBoxControlRAM.Refresh();
                    break;
                case "HARD DISK":
                    listHD.Add(gridViewResult.GetFocusedRowCellValue("Ten").ToString());
                    listHD = listHD.Distinct().ToList();
                    listBoxControlHD.DataSource = listHD;
                    listBoxControlHD.Refresh();
                    break;
            }
        }
    }
}