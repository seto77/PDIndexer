using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using Crystallography;
using Crystallography.Controls;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PDIndexer;

/// <summary>
/// FormCrystal �̊T�v�̐����ł��B
/// </summary>
public partial class FormCrystal : Form
{
    public FormMain formMain;
    public int atomSeriesNum;
    public int SymmetrySeriesNumber;
    public bool[] IsHitCrystal;
    public bool SkipEvent = false;


    public FormCrystal()
    {
        InitializeComponent();
        crystalControl.CrystalChanged += crystalControl_CrystalChanged;

        crystalDatabaseControl.ProgressChanged += CrystalDatabaseControl_ProgressChanged;

        typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dataGridViewCrystal, true, null);

        searchCrystalControl.CrystalDatabaseControl = crystalDatabaseControl;
        this.AcceptButton = searchCrystalControl.buttonSearch;
    }

    private void CrystalDatabaseControl_ProgressChanged(object sender, double progress, string message)
    {
        if (message.Contains("Total"))
            crystalDatabaseControl.CrystalChanged += crystalDatabaseControl_CrystalChanged;
    }

    private void FormCrystal_Load(object sender, EventArgs e)
    {
        if (File.Exists(formMain.UserAppDataPath + "StdDB.cdb3"))
            crystalDatabaseControl.ReadDatabase(formMain.UserAppDataPath + "StdDB.cdb3");
    }

    private void crystalDatabaseControl_CrystalChanged(object sender, EventArgs e)
    {
        if (SkipEvent) return;
        crystalControl.Crystal = crystalDatabaseControl.Crystal;
    }

    void crystalControl_CrystalChanged(object sender, EventArgs e)
    {
        formMain.InitializeCrystalPlane();
        formMain.Draw();
        formMain.SetFormFitting();
        formMain.SetFormEOS();
    }

    private void textBoxNumOnly_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if ((e.KeyChar < '.' || e.KeyChar > '9') && e.KeyChar != '\b' && e.KeyChar != 3 && e.KeyChar != 22)
            e.Handled = true;
    }
    private void buttonAddCrystal_Click(object sender, System.EventArgs e)
    {
        crystalControl.GenerateFromInterface();
        if (crystalControl.Crystal != null)
        {
            crystalControl.Crystal.SaveInitialCellConstants();
            AddCrystal(crystalControl.Crystal);
        }
    }

    public void buttonChangeCrystal_Click(object sender, System.EventArgs e)
    {
        if (((Crystal)dataSet.DataTableCrystal.Rows[bindingSource.Position][1]).Reserved && (ModifierKeys & Keys.Control) != Keys.Control)
            return;
        crystalControl.GenerateFromInterface();
        formMain.InitializeCrystalPlane();
        if (crystalControl.Crystal != null)
            ChangeCrystal(crystalControl.Crystal);
    }

    private void FormCrystal_Closed(object sender, System.EventArgs e)
    {
        if (formMain != null)
            formMain.checkBoxCrystalParameter.Checked = false;
    }

    private void FormCrystal_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        formMain.checkBoxCrystalParameter.Checked = false;
    }

    //�ꏊ���ύX���ꂽ�Ƃ�
    private void bindingSource_PositionChanged(object sender, EventArgs e)
    {
        formMain.SelectedCrysatlIndex = bindingSource.Position;
        formMain.Draw();
    }


    //�V�K�ǉ����Ăяo���ꂽ�Ƃ�
    public void AddCrystal(Crystal cry)
    {
        if (cry != null)
        {

            Bitmap bmp = new Bitmap(18, 18);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(cry.Argb));
            formMain.dataSet.DataTableCrystal.Rows.Add(new object[] { false, cry, bmp });
            formMain.bindingSourceCrystal.Position = formMain.bindingSourceCrystal.List.Count - 1;
            formMain.dataGridViewCrystals_CellMouseClick
                (this, new DataGridViewCellMouseEventArgs(0, formMain.dataSet.DataTableCrystal.Rows.Count - 1, 0, 0,
                    new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, 0, 0, 0)));

            //formMain.bindingSourceCrystal.Position = formMain.bindingSourceCrystal.List.Count - 1;
            //bindingSource.Position = bindingSource.List.Count - 1;
            //formMain.SelectedCrysatlIndex = bindingSource.Position;
            formMain.InitializeCrystalPlane();

            formMain.Draw();
            if (crystalControl.Enabled == false)
                crystalControl.Enabled = true;
        }
    }

    //�ύX���Ăяo���ꂽ�Ƃ�
    public void ChangeCrystal(Crystal cry)
    {
        if (cry != null && bindingSource.Position >= 0)
        {
            Bitmap bmp = new Bitmap(22, 22);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(cry.Argb));
            dataSet.DataTableCrystal.Rows[bindingSource.Position][1] = cry;
            dataSet.DataTableCrystal.Rows[bindingSource.Position][2] = bmp;
            formMain.InitializeCrystalPlane();
            formMain.Draw();
            formMain.SetFormFitting();
            formMain.SetFormEOS();
        }
    }
    //�폜
    private void buttonDeleteCrystal_Click(object sender, System.EventArgs e)
    {
        if (((Crystal)dataSet.DataTableCrystal.Rows[bindingSource.Position][1]).Reserved && (ModifierKeys & Keys.Control) != Keys.Control)
            return;
        dataSet.DataTableCrystal.RemoveItem(bindingSource.Position);
        formMain.InitializeCrystalPlane();
        formMain.Draw();
        formMain.SetFormFitting();
        formMain.SetFormEOS();

    }
    //���ׂč폜
    private void buttonAllClear_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Do you want to clear all crystals?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            for (int i = 0; i < dataSet.DataTableCrystal.Items.Count; i++)
                if (((Crystal)dataSet.DataTableCrystal.Rows[i][1]).Reserved == false)
                    dataSet.DataTableCrystal.RemoveItem(i--);
    }

    private void checkBoxShowPeakOverProfiles_CheckedChanged(object sender, EventArgs e)
    {
        checkBoxCalculateIntensity.Enabled = checkBoxShowPeakOverProfiles.Checked;
        checkBoxVariableRatioOfIntensity.Enabled = checkBoxCalculateIntensity.Checked && checkBoxCalculateIntensity.Enabled;
        formMain.InitializeCrystalPlane();
        formMain.Draw();
    }

    private void checkBoxCalculateIntensity_CheckedChanged(object sender, EventArgs e)
    {
        checkBoxVariableRatioOfIntensity.Enabled = checkBoxCalculateIntensity.Checked;
        formMain.InitializeCrystalPlane();
        formMain.Draw();
    }

    private void checkBoxVariableRatioOfIntensity_CheckedChanged(object sender, EventArgs e)
    {
        formMain.InitializeCrystalPlane();
        formMain.Draw();
    }

    private void checkBoxShowPeakUnderProfile_CheckedChanged(object sender, EventArgs e)
    {
        numericUpDownHeightOfBottomPeak.Enabled = checkBoxShowPeakUnderProfile.Checked;
        formMain.HeightOfBottomPeaks = (float)numericUpDownHeightOfBottomPeak.Value;
        if (checkBoxShowPeakUnderProfile.Checked)
            formMain.BottomMargin = (formMain.HeightOfBottomPeaks + 4) * dataSet.DataTableCrystal.CheckedItems.Count;
        else
            formMain.BottomMargin = 0;
        formMain.InitializeCrystalPlane();
        formMain.Draw();
    }

    private void checkBoxCombineSameDspacingPeaks_CheckedChanged(object sender, EventArgs e)
    {
        flowLayoutPanel1.Enabled = checkBoxCombineSameDspacingPeaks.Checked;
        formMain.InitializeCrystalPlane();
        formMain.Draw();
    }

    private void radioButtonOnlySelectedCrystal_CheckedChanged(object sender, EventArgs e)
    {
        formMain.InitializeCrystalPlane();
        formMain.Draw();
    }

    private void checkBoxInvisibleWeakPeak_CheckedChanged(object sender, EventArgs e)
    {
        numericUpDownThresholdIntesity.Enabled = checkBoxInvisibleWeakPeak.Checked;
        formMain.InitializeCrystalPlane();
        formMain.Draw();
    }

    private void buttonUpper_Click(object sender, EventArgs e)
    {
        int n = bindingSource.Position;
        if (n < 1 || ((Crystal)dataSet.DataTableCrystal.Rows[n - 1][1]).Reserved == true) return;
        dataSet.DataTableCrystal.MoveItem(n, n - 1);
        bindingSource.Position = n - 1;
    }

    private void buttonLower_Click(object sender, EventArgs e)
    {
        int n = bindingSource.Position;
        if (n < 0 || ((Crystal)dataSet.DataTableCrystal.Rows[n][1]).Reserved || n >= dataSet.DataTableCrystal.Items.Count - 1) return;
        dataSet.DataTableCrystal.MoveItem(n, n + 1);
        bindingSource.Position = n + 1;

    }

    private void FormCrystal_VisibleChanged(object sender, EventArgs e)
    {
        //dataGridView�̐F�̐ݒ�
        for (int i = 0; i < dataGridViewCrystal.Rows.Count; i++)
            dataGridViewCrystal.Rows[i].DefaultCellStyle = formMain.dataGridViewCrystals.Rows[i].DefaultCellStyle;
    }

    private void FormCrystal_KeyDown(object sender, KeyEventArgs e)
    {
        formMain.FormMain_KeyDown(sender, e);
    }




    private void numericUpDownThreshold_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            FormNumericUpdownControl formNumericUpdownControl = new FormNumericUpdownControl((NumericUpDown)sender);
            formNumericUpdownControl.ShowDialog();
        }
    }

    private void dataGridViewCrystal_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) => formMain.dataGridViewCrystals_CellMouseClick(sender, e);

    private void dataGridViewCrystal_KeyDown(object sender, KeyEventArgs e) => formMain.dataGridViewCrystals_KeyDown(sender, e);

}

