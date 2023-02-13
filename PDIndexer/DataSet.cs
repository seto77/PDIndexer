using System.Collections.Generic;
using Crystallography;
using System.Data;
using System.Drawing;

namespace PDIndexer;

public partial class DataSet
{
    partial class DataTablePeakFittingDataTable
    {
        /// <summary>
        /// i番目のアイテムをDataTablePeakFittingRow形式で返す
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public DataTablePeakFittingRow GetRow(int i) => i < Rows.Count ? Rows[i] as DataTablePeakFittingRow : null;

        public void SetCheckState(int i, bool state) 
        {
            if (i < Rows.Count)
                (Rows[i] as DataTablePeakFittingRow).Check = state;
        }

        internal void Add(Plane p)
        {
            var dr = NewDataTablePeakFittingRow();
            SetDataTablePeakFittingRow(dr, p);
            Rows.Add(dr);
        }

        private static void SetDataTablePeakFittingRow(DataTablePeakFittingRow r, Plane p = null)
        {
            if (p == null && r.PlaneObject is Plane plane)
                p = plane;

            r.PlaneObject = p;

            r.HKL = p.strHKL == null ? "" : p.strHKL;
            r.Check = p.IsFittingChecked;
            r.CalcX = p.XCalc;
            r.X = p.peakFunction.X;
            r.XErr = p.peakFunction.Xerr;
            r.FWHM = p.peakFunction.Hk;
            r.R = p.peakFunction.Residual;
            r.Function = p.peakFunction.Option switch
            {
                PeakFunctionForm.Simple => "Simple",
                PeakFunctionForm.PseudoVoigt => "Sym PV",
                PeakFunctionForm.Peason => "Sym Pea",
                PeakFunctionForm.SplitPseudoVoigt => "Spl PV",
                _ => "Spl Pea",
            };
            r.Intensity = p.observedIntensity;
            r.Weight = p.Weight;
        }

        internal void RemoveAt(int i)
        {
            if (i < Rows.Count)
                Rows.RemoveAt(i);
        }

        internal void Replace(int i, Plane plane)
        {
            if (i < Rows.Count)
                SetDataTablePeakFittingRow((DataTablePeakFittingRow)Rows[i], plane);
        }

        internal void Refresh()
        {
            foreach (var row in Rows)
                SetDataTablePeakFittingRow((DataTablePeakFittingRow)row);
        }
    }

    partial class DataTableCrystalCandidatesDataTable
    {
    }

    partial class DataTableProfileDataTable
    {
        public bool AllChecked
        {
            set
            {
                if (value == true)
                {
                    for (int i = 0; i < this.Rows.Count; i++)
                        this.Rows[i][0] = true;
                }
            }
            get
            {
                bool flag = true;
                for (int i = 0; i < this.Rows.Count; i++)
                    if (!((bool)this.Rows[i][0]))
                        flag = false;
                return flag;
            }
        }

        public bool AllUnchecked
        {
            set
            {
                if (value == true)
                {
                    for (int i = 0; i < this.Rows.Count; i++)
                        this.Rows[i][0] = false;
                }
            }
            get
            {
                bool flag = true;
                for (int i = 0; i < this.Rows.Count; i++)
                    if ((bool)this.Rows[i][0])
                        flag = false;
                return flag;
            }
        }

        /// <summary>
        /// チェックされているプロファイル群をList形式で取得
        /// </summary>
        public List<DiffractionProfile> CheckedItems
        {
            set { }
            get
            {
                List<DiffractionProfile> p = new List<DiffractionProfile>();
                for (int i = 0; i < this.Rows.Count; i++)
                    if ((bool)this.Rows[i][0])
                        p.Add((DiffractionProfile)this.Rows[i][1]);
                return p;
            }
        }

        /// <summary>
        /// プロファイル群をList形式で取得
        /// </summary>
        public List<DiffractionProfile> Items
        {
            set { }
            get
            {
                try
                {
                    List<DiffractionProfile> p = new List<DiffractionProfile>();
                    for (int i = 0; i < this.Rows.Count; i++)
                        p.Add((DiffractionProfile)this.Rows[i][1]);
                    return p;
                }
                catch { return new List<DiffractionProfile>(); }
            }
        }

        public void MoveItem(int srcIndex, int destIndex)
        {
            if (srcIndex < this.Rows.Count && destIndex < this.Rows.Count)
            {
                bool check = (bool)this.Rows[srcIndex][0];
                this.Rows[srcIndex][0] = this.Rows[destIndex][0];
                this.Rows[destIndex][0] = check;


                DiffractionProfile c = (DiffractionProfile)this.Rows[srcIndex][1];
                this.Rows[srcIndex][1] = this.Rows[destIndex][1];
                this.Rows[destIndex][1] = c;

                Bitmap bmp = (Bitmap)this.Rows[srcIndex][2];
                this.Rows[srcIndex][2] = this.Rows[destIndex][2];
                this.Rows[destIndex][2] = bmp;

            }
        }

        /// <summary>
        /// index位置の行を削除する
        /// </summary>
        /// <param name="index"></param>
        public void RemoveItem(int index)
        {
            if (index < this.Rows.Count)
                this.Rows.RemoveAt(index);
        }

        /// <summary>
        /// index位置に行を挿入する
        /// </summary>
        /// <param name="index"></param>
        public void InsertItemAt(int index, bool check, DiffractionProfile dp)
        {
            if (index < this.Rows.Count)
            {
                DataRow dr = this.NewDataTableProfileRow();
                dr[0] = check;
                dr[1] = dp;
                this.Rows.InsertAt(dr, index);
            }
        }

        /// <summary>
        /// index行のデータがチェックされているか
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        internal bool GetItemChecked(int index)
        {
            if (index < 0 || this.Rows.Count <= index)
                return false;
            try
            {
                return (bool)this.Rows[index][0];
            }
            catch { return false; }
        }

        /// <summary>
        /// index行のデータのチェック状態を設定する
        /// </summary>
        /// <param name="index"></param>
        /// <param name="check"></param>
        internal void SetItemChecked(int index, bool check)
        {
            if (index < 0 || this.Rows.Count <= index) return;
            this.Rows[index][0] = check;
        }

        /// <summary>
        /// i番目の行が、チェック済みアイテムの中で何番目であるかをかえす。そもそもチェックされていない場合は-1を返す)
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int ConvertRawIndexToCheckedIndex(int rawIndex)
        {
            if (rawIndex > Rows.Count || !GetItemChecked(rawIndex)) return -1;
            int n = -1;
            for (int i = 0; i <= rawIndex; i++)
                if (GetItemChecked(i))
                    n++;
            return n;
        }

        /// <summary>
        /// checkedIndex
        /// </summary>
        /// <param name="checkedIndex"></param>
        /// <returns></returns>
        public int ConvertCheckedIndexToRawIndex(int checkedIndex)
        {
            if (checkedIndex >= CheckedItems.Count || checkedIndex < 0) return -1;
            int n = -1;
            for (int i = 0; i < Items.Count; i++)
                if (GetItemChecked(i))
                {
                    n++;
                    if (n == checkedIndex)
                        return i;
                }
            return -1;
            //return Items.IndexOf(CheckedItems[checkedIndex]);
        }





    }

    partial class DataTableDiffractionDataDataTable
    {
    }

    partial class DataTableCrystalDataTable
    {
        public List<Crystal> CheckedItems
        {
            set { }
            get
            {
                List<Crystal> c = new List<Crystal>();
                for (int i = 0; i < this.Rows.Count; i++)
                    if ((bool)this.Rows[i][0])
                        c.Add((Crystal)this.Rows[i][1]);
                return c;
            }
        }

        public int[] CheckedIndices
        {
            set { }
            get
            {
                List<int> indices = new List<int>();
                for (int i = 0; i < this.Rows.Count; i++)
                    if ((bool)this.Rows[i][0])
                        indices.Add(i);
                return indices.ToArray();
            }
        }

        public List<Crystal> Items
        {
            set { }
            get
            {
                List<Crystal> c = new List<Crystal>();
                for (int i = 0; i < this.Rows.Count; i++)
                    c.Add((Crystal)this.Rows[i][1]);
                return c;
            }
        }

        public void MoveItem(int srcIndex, int destIndex)
        {
            if (srcIndex < this.Rows.Count && destIndex < this.Rows.Count)
            {
                bool check = (bool)this.Rows[srcIndex][0];
                this.Rows[srcIndex][0] = this.Rows[destIndex][0];
                this.Rows[destIndex][0] = check;


                Crystal c = (Crystal)this.Rows[srcIndex][1];
                this.Rows[srcIndex][1] = this.Rows[destIndex][1];
                this.Rows[destIndex][1] = c;

                Bitmap bmp = (Bitmap)this.Rows[srcIndex][2];
                this.Rows[srcIndex][2] = this.Rows[destIndex][2];
                this.Rows[destIndex][2] = bmp;

            }
        }

        /// <summary>
        /// index位置の行を削除する
        /// </summary>
        /// <param name="index"></param>
        public void RemoveItem(int index)
        {
            if (index < this.Rows.Count)
                this.Rows.RemoveAt(index);
        }

        /// <summary>
        /// index位置に行を挿入する
        /// </summary>
        /// <param name="index"></param>
        public void InsertItemAt(int index, bool check, Crystal cry)
        {
            if (index < this.Rows.Count)
            {
                DataRow dr = this.NewDataTableCrystalRow();
                dr[0] = check;
                dr[1] = cry;
                this.Rows.InsertAt(dr, index);
            }
        }

        /// <summary>
        /// index行のデータがチェックされているか
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        internal bool GetItemChecked(int index)
        {
            if (index < 0 || this.Rows.Count <= index) return false;
            return (bool)this.Rows[index][0];
        }

        /// <summary>
        /// i番目の行が、チェック済みアイテムの中で何番目であるかをかえす。そもそもチェックされていない場合は-1を返す)
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int ConvertRawIndexToCheckedIndex(int rawIndex)
        {
            if (rawIndex > Rows.Count || !GetItemChecked(rawIndex)) return -1;
            int n = -1;
            for (int i = 0; i <= rawIndex; i++)
                if (GetItemChecked(i))
                    n++;
            return n;
        }

        /// <summary>
        /// checkedIndex
        /// </summary>
        /// <param name="checkedIndex"></param>
        /// <returns></returns>
        public int ConvertCheckedIndexToRawIndex(int checkedIndex)
        {
            if (checkedIndex >= CheckedItems.Count || checkedIndex < 0) return -1;
            int n = -1;
            for (int i = 0; i < Items.Count; i++)
                if (GetItemChecked(i))
                {
                    n++;
                    if (n == checkedIndex)
                        return i;
                }
            return -1;
            //return Items.IndexOf(CheckedItems[checkedIndex]);
        }



    }
}
