using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItcastCater.Model
{
    public class ProductInfo
    {
        #region Model
        private int _proid;
        private int? _catid;
        private string _proname;
        private decimal? _procost;
        private string _prospell;
        private decimal? _proprice;
        private string _prounit;
        private string _remark;
        private int? _delflag;
        private DateTime? _subtime;
        private decimal? _prostock;
        private string _pronum;
        private int? _subby;
        /// <summary>
        /// 商品主键
        /// </summary>
        public int ProId
        {
            set { _proid = value; }
            get { return _proid; }
        }
        /// <summary>
        /// 商品类型id
        /// </summary>
        public int? CatId
        {
            set { _catid = value; }
            get { return _catid; }
        }
        /// <summary>
        /// 商品名字
        /// </summary>
        public string ProName
        {
            set { _proname = value; }
            get { return _proname; }
        }
        /// <summary>
        /// 商品成本
        /// </summary>
        public decimal? ProCost
        {
            set { _procost = value; }
            get { return _procost; }
        }
        /// <summary>
        /// 商品拼音
        /// </summary>
        public string ProSpell
        {
            set { _prospell = value; }
            get { return _prospell; }
        }
        /// <summary>
        /// 商品实际价格
        /// </summary>
        public decimal? ProPrice
        {
            set { _proprice = value; }
            get { return _proprice; }
        }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string ProUnit
        {
            set { _prounit = value; }
            get { return _prounit; }
        }
        /// <summary>
        /// 商品备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 商品删除标识
        /// </summary>
        public int? DelFlag
        {
            set { _delflag = value; }
            get { return _delflag; }
        }
        /// <summary>
        /// 商品提交时间
        /// </summary>
        public DateTime? SubTime
        {
            set { _subtime = value; }
            get { return _subtime; }
        }
        /// <summary>
        /// 商品库存
        /// </summary>
        public decimal? ProStock
        {
            set { _prostock = value; }
            get { return _prostock; }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProNum
        {
            set { _pronum = value; }
            get { return _pronum; }
        }
        /// <summary>
        /// 商品提交人
        /// </summary>
        public int? SubBy
        {
            set { _subby = value; }
            get { return _subby; }
        }
        #endregion Model
    }
}
