//-----------------------------------------------------------------------
// <copyright file="ToDoList.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Collections;
    
	/// <summary>
	/// ToDoList ��ժҪ˵����
	/// </summary>
	[Serializable]
	public class ToDoList
    {
        #region Field
        private int id = -1;
		private int taskId = -1;
	    #endregion

        /// <summary>
        /// �������ˡ�
        /// </summary>
        public ToDoList()
        {
            this.Guid = string.Empty;
            this.ToDoTime = DateTime.MinValue;
            this.ReferUserName = string.Empty;
            this.Refer = string.Empty;
            this.URL = string.Empty;
            this.Description = string.Empty;
            this.ProcessID = -1;
            this.SubmitDate = DateTime.MinValue;
            this.HandlerUserName = string.Empty;
            this.Handler = string.Empty;
            this.Priority = PriorityEnum.Normal;
            this.Name = string.Empty;
            this.InvalidateTime = DateTime.MaxValue;
            this.AwokeTime = DateTime.MinValue;
        }

        #region Property

	    /// <summary>
	    /// ����ʱ��
	    /// </summary>
	    public DateTime AwokeTime { get; set; }

	    /// <summary>
	    /// ʧЧʱ��
	    /// </summary>
	    public DateTime InvalidateTime { get; set; }

	    /// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			get
            {
                return this.id;
            }
			set
			{
				if (value < -1) 
                    this.id = -1;
				else 
                    this.id = value;
			}
		}

		/// <summary>
		/// ����ID
		/// </summary>
		public int TaskID
		{
			get
            {
                return this.taskId;
            }
			set
			{
				if (value < -1) 
                    this.taskId = -1;
				else 
                    this.taskId = value;
			}
		}

	    /// <summary>
	    /// ����
	    /// </summary>
	    public string Name { get; set; }

	    /// <summary>
	    /// ���ȼ�
	    /// </summary>
	    public PriorityEnum Priority { get; set; }

	    /// <summary>
	    /// ����������
	    /// </summary>
	    public string Handler { get; set; }

	    /// <summary>
	    /// �������û���
	    /// </summary>
	    public string HandlerUserName { get; set; }

	    /// <summary>
	    /// �ύ����
	    /// </summary>
	    public DateTime SubmitDate { get; set; }

	    /// <summary>
	    /// �Ǹ�����
	    /// </summary>
	    public int ProcessID { get; set; }

	    /// <summary>
	    /// ����
	    /// </summary>
	    public string Description { get; set; }

	    /// <summary>
	    /// �Ƿ���URL
	    /// </summary>
	    public int HasUrl { get; set; }

	    /// <summary>
	    /// URL
	    /// </summary>
	    public string URL { get; set; }

	    /// <summary>
	    /// �ύ��
	    /// </summary>
	    public string Refer { get; set; }

	    /// <summary>
	    /// �ύ���û���
	    /// </summary>
	    public string ReferUserName { get; set; }

	    /// <summary>
	    /// �Ƿ��Ѿ����
	    /// </summary>
	    public int HasTodo { get; set; }

	    /// <summary>
	    /// ���ʱ��
	    /// </summary>
	    public DateTime ToDoTime { get; set; }

	    /// <summary>
	    /// GUID
	    /// </summary>
	    public string Guid { get; set; }

        /// <summary>
        /// ��������Id��
        /// </summary>
        public int TaskTypeId { get; set; }
	    #endregion
    }

    /// <summary>
	/// �������˼��ϡ�
	/// </summary>
	[Serializable]
	public class ToDoLists : CollectionBase
    {
        #region Ctor
        /// <summary>
		/// ���캯��
		/// </summary>
		public ToDoLists()
        { }
        #endregion

        /// <summary>
		/// ����
		/// </summary>
        /// <param name="index">�����š�</param>
		public ToDoList this[int index]
		{
			get{return (ToDoList)this.List[index];}
			set{this.List[index] = value;}
        }

        #region Method

        /// <summary>
		/// ����
		/// </summary>
		/// <param name="item">��</param>
		/// <returns>int</returns>
		public int Add(ToDoList item)
		{
			return this.List.Add(item);
		}

		/// <summary>
		/// ����
		/// </summary>
		/// <param name="index">���</param>
		/// <param name="item">��</param>
		public void Insert(int index,ToDoList item)
		{
			this.List.Insert(index,item);
		}

		/// <summary>
		/// �Ƴ�
		/// </summary>
		/// <param name="item">��</param>
		public void Remove(ToDoList item)
		{
			this.List.Remove(item);
        }
        #endregion
    }
}
