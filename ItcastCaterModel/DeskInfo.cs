using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItcastCater.Model
{
    public class DeskInfo
    {
        private string _deskStateString;
        //餐桌的字符串数据
        public string DeskStateString
        {
            get { return _deskStateString; }
            set { _deskStateString = value; }
        }
        //DeskId RoomId DeskName DeskRemark DeskRegion DeskState DelFlag SubTime SubBy
        private int _deskId;

        public int DeskId
        {
            get { return _deskId; }
            set { _deskId = value; }
        }
        private int _roomId;

        public int RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }
        private string _deskName;

        public string DeskName
        {
            get { return _deskName; }
            set { _deskName = value; }
        }
        private string _deskRemark;

        public string DeskRemark
        {
            get { return _deskRemark; }
            set { _deskRemark = value; }
        }
        private string _deskRegion;

        public string DeskRegion
        {
            get { return _deskRegion; }
            set { _deskRegion = value; }
        }
        private int? _deskState;

        public int? DeskState
        {
            get { return _deskState; }
            set { _deskState = value; }
        }
        private int? _delFlag;

        public int? DelFlag
        {
            get { return _delFlag; }
            set { _delFlag = value; }
        }
        private DateTime? _subTime;

        public DateTime? SubTime
        {
            get { return _subTime; }
            set { _subTime = value; }
        }
        private int? _subBy;

        public int? SubBy
        {
            get { return _subBy; }
            set { _subBy = value; }
        }
    }
}
