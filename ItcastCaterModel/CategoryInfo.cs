using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItcastCater.Model
{
    /// <summary>
    /// 商品分类
    /// </summary>
    public class CategoryInfo
    {
        #region Model
        private int _catid;
        private string _catname;
        private string _catnum;
        private string _remark;
        private int? _delflag;
        private DateTime? _subtime;
        private int? _subby;
        /// <summary>
        /// 商品分类主键
        /// </summary>
        public int CatId
        {
            set { _catid = value; }
            get { return _catid; }
        }
        /// <summary>
        /// 商品分类名字
        /// </summary>
        public string CatName
        {
            set { _catname = value; }
            get { return _catname; }
        }
        /// <summary>
        /// 商品分类编号
        /// </summary>
        public string CatNum
        {
            set { _catnum = value; }
            get { return _catnum; }
        }
        /// <summary>
        /// 商品分类备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 商品分类删除标识
        /// </summary>
        public int? DelFlag
        {
            set { _delflag = value; }
            get { return _delflag; }
        }
        /// <summary>
        /// 商品分类提交时间
        /// </summary>
        public DateTime? SubTime
        {
            set { _subtime = value; }
            get { return _subtime; }
        }
        /// <summary>
        /// 商品分类提交人 
        /// </summary>
        public int? SubBy
        {
            set { _subby = value; }
            get { return _subby; }
        }
        #endregion Model

    }
}
