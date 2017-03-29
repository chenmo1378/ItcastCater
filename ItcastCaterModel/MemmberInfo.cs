using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItcastCater.Model
{
    public class MemmberInfo
    {
        #region Model
        private int _memmberid;
        private string _memname;
        private string _memphone;
        private string _memmobilephone;
        private string _memaddress;
        private int _memtype;
        private string _memnum;
        private string _memgender;
        private decimal? _memdiscount = 1.00M;
        private decimal? _memmoney = 0M;
        private int? _delflag;
        private DateTime? _subtime;
        private int? _memintegral;
        private DateTime? _memendservertime;
        private DateTime? _membirthdaty;

        //冗余属性
        public string MemTpName
        {
            get;
            set;
        }
        /// <summary>
        /// 会员主键id
        /// </summary>
        public int MemmberId
        {
            set { _memmberid = value; }
            get { return _memmberid; }
        }
        /// <summary>
        /// 会员名字
        /// </summary>
        public string MemName
        {
            set { _memname = value; }
            get { return _memname; }
        }
        /// <summary>
        /// 会员电话
        /// </summary>
        public string MemPhone
        {
            set { _memphone = value; }
            get { return _memphone; }
        }
        /// <summary>
        /// 会员手机
        /// </summary>
        public string MemMobilePhone
        {
            set { _memmobilephone = value; }
            get { return _memmobilephone; }
        }
        /// <summary>
        /// 会员地址
        /// </summary>
        public string MemAddress
        {
            set { _memaddress = value; }
            get { return _memaddress; }
        }
        /// <summary>
        /// 会员类型
        /// </summary>
        public int MemType
        {
            set { _memtype = value; }
            get { return _memtype; }
        }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemNum
        {
            set { _memnum = value; }
            get { return _memnum; }
        }
        /// <summary>
        /// 会员性别
        /// </summary>
        public string MemGender
        {
            set { _memgender = value; }
            get { return _memgender; }
        }
        /// <summary>
        /// 会员折扣
        /// </summary>
        public decimal? MemDiscount
        {
            set { _memdiscount = value; }
            get { return _memdiscount; }
        }
        /// <summary>
        /// 会员余额
        /// </summary>
        public decimal? MemMoney
        {
            set { _memmoney = value; }
            get { return _memmoney; }
        }
        /// <summary>
        /// 会员删除标识
        /// </summary>
        public int? DelFlag
        {
            set { _delflag = value; }
            get { return _delflag; }
        }
        /// <summary>
        /// 会员提交时间
        /// </summary>
        public DateTime? SubTime
        {
            set { _subtime = value; }
            get { return _subtime; }
        }
        /// <summary>
        /// 会员积分
        /// </summary>
        public int? MemIntegral
        {
            set { _memintegral = value; }
            get { return _memintegral; }
        }
        /// <summary>
        /// 会员结束时间
        /// </summary>
        public DateTime? MemEndServerTime
        {
            set { _memendservertime = value; }
            get { return _memendservertime; }
        }
        /// <summary>
        /// 会员生日
        /// </summary>
        public DateTime? MemBirthdaty
        {
            set { _membirthdaty = value; }
            get { return _membirthdaty; }
        }
        #endregion Model

    }
}
