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
	/// ToDoList 的摘要说明。
	/// </summary>
	[Serializable]
	public class ToDoList
    {
        #region Field
        private int id = -1;
		private int taskId = -1;
	    #endregion

        /// <summary>
        /// 代办事宜。
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
	    /// 提醒时间
	    /// </summary>
	    public DateTime AwokeTime { get; set; }

	    /// <summary>
	    /// 失效时间
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
		/// 任务ID
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
	    /// 名称
	    /// </summary>
	    public string Name { get; set; }

	    /// <summary>
	    /// 优先级
	    /// </summary>
	    public PriorityEnum Priority { get; set; }

	    /// <summary>
	    /// 处理人姓名
	    /// </summary>
	    public string Handler { get; set; }

	    /// <summary>
	    /// 处理人用户名
	    /// </summary>
	    public string HandlerUserName { get; set; }

	    /// <summary>
	    /// 提交日期
	    /// </summary>
	    public DateTime SubmitDate { get; set; }

	    /// <summary>
	    /// 那个流程
	    /// </summary>
	    public int ProcessID { get; set; }

	    /// <summary>
	    /// 描述
	    /// </summary>
	    public string Description { get; set; }

	    /// <summary>
	    /// 是否有URL
	    /// </summary>
	    public int HasUrl { get; set; }

	    /// <summary>
	    /// URL
	    /// </summary>
	    public string URL { get; set; }

	    /// <summary>
	    /// 提交人
	    /// </summary>
	    public string Refer { get; set; }

	    /// <summary>
	    /// 提交人用户名
	    /// </summary>
	    public string ReferUserName { get; set; }

	    /// <summary>
	    /// 是否已经完成
	    /// </summary>
	    public int HasTodo { get; set; }

	    /// <summary>
	    /// 完成时间
	    /// </summary>
	    public DateTime ToDoTime { get; set; }

	    /// <summary>
	    /// GUID
	    /// </summary>
	    public string Guid { get; set; }

        /// <summary>
        /// 任务类型Id。
        /// </summary>
        public int TaskTypeId { get; set; }
	    #endregion
    }

    /// <summary>
	/// 待办事宜集合。
	/// </summary>
	[Serializable]
	public class ToDoLists : CollectionBase
    {
        #region Ctor
        /// <summary>
		/// 构造函数
		/// </summary>
		public ToDoLists()
        { }
        #endregion

        /// <summary>
		/// 索引
		/// </summary>
        /// <param name="index">索引号。</param>
		public ToDoList this[int index]
		{
			get{return (ToDoList)this.List[index];}
			set{this.List[index] = value;}
        }

        #region Method

        /// <summary>
		/// 增加
		/// </summary>
		/// <param name="item">项</param>
		/// <returns>int</returns>
		public int Add(ToDoList item)
		{
			return this.List.Add(item);
		}

		/// <summary>
		/// 插入
		/// </summary>
		/// <param name="index">序号</param>
		/// <param name="item">项</param>
		public void Insert(int index,ToDoList item)
		{
			this.List.Insert(index,item);
		}

		/// <summary>
		/// 移除
		/// </summary>
		/// <param name="item">项</param>
		public void Remove(ToDoList item)
		{
			this.List.Remove(item);
        }
        #endregion
    }
}
