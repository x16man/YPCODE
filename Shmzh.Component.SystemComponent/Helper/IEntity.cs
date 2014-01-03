using System;
using System.ComponentModel;

namespace Shmzh.Components.SystemComponent
{
	/// <summary>
    /// List of possible state for an entity.
    /// </summary>
	public enum EntityState
    {
        /// <summary>
        /// Entity is unchanged
        /// </summary>
        Unchanged=0, 

        /// <summary>
        /// Entity is new
        /// </summary>
        Added=1, 

        /// <summary>
        /// Entity has been modified
        /// </summary>
        Changed=2, 

        /// <summary>
        /// Entity has been deleted
        /// </summary>
        Deleted=3
    }
	
	/// <summary>
	/// The interface that each business object of the model implements.
	/// </summary>
	public interface IEntity
	{
		/// <summary>
		///	The name of the underlying database table.
		/// </summary>
		string TableName { get;}

		/// <summary>
		///	Indicates if the object has been modified from its original state.
		/// </summary>
		///<value>True if object has been modified from its original state; otherwise False;</value>
		bool IsDirty {get;}
		
		/// <summary>
		///	Indicates if the object is new.
		/// </summary>
		///<value>True if objectis new; otherwise False;</value>
		bool IsNew {get;}

		/// <summary>
		/// True if object has been marked as deleted. ReadOnly.
		/// </summary>
		bool IsDeleted {get;}
	
		/// <summary>
		/// Returns one of EntityState enum values - intended to replace IsNew, IsDirty, IsDeleted.
		/// </summary>
		EntityState EntityState {get;}
		
		/// <summary>
		/// Accepts the changes made to this object by setting each flags to false.
		/// </summary>
		void AcceptChanges();
		
		/// <summary>
		/// Marks entity to be deleted.
		/// </summary>
		void MarkToDelete();
				
		/// <summary>
        /// Gets or sets the parent collection.
        /// </summary>
        /// <value>The parent collection.</value>
		object ParentCollection{get;set;}
		
		
	}
}
