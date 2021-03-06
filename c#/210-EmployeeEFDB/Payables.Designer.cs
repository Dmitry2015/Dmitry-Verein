﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("PayablesModel", "FK_DepartmentEmployee", "Department1", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(VendorMaintenance.Department), "Employee1", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(VendorMaintenance.Employee), true)]

#endregion

namespace VendorMaintenance
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class PayablesEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new PayablesEntities object using the connection string found in the 'PayablesEntities' section of the application configuration file.
        /// </summary>
        public PayablesEntities() : base("name=PayablesEntities", "PayablesEntities")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new PayablesEntities object.
        /// </summary>
        public PayablesEntities(string connectionString) : base(connectionString, "PayablesEntities")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new PayablesEntities object.
        /// </summary>
        public PayablesEntities(EntityConnection connection) : base(connection, "PayablesEntities")
        {
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Department> Departments
        {
            get
            {
                if ((_Departments == null))
                {
                    _Departments = base.CreateObjectSet<Department>("Departments");
                }
                return _Departments;
            }
        }
        private ObjectSet<Department> _Departments;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Employee> Employees
        {
            get
            {
                if ((_Employees == null))
                {
                    _Employees = base.CreateObjectSet<Employee>("Employees");
                }
                return _Employees;
            }
        }
        private ObjectSet<Employee> _Employees;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Departments EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToDepartments(Department department)
        {
            base.AddObject("Departments", department);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Employees EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToEmployees(Employee employee)
        {
            base.AddObject("Employees", employee);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PayablesModel", Name="Department")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Department : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Department object.
        /// </summary>
        /// <param name="departmentID">Initial value of the DepartmentID property.</param>
        /// <param name="deptName">Initial value of the DeptName property.</param>
        public static Department CreateDepartment(global::System.Int32 departmentID, global::System.String deptName)
        {
            Department department = new Department();
            department.DepartmentID = departmentID;
            department.DeptName = deptName;
            return department;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 DepartmentID
        {
            get
            {
                return _DepartmentID;
            }
            set
            {
                if (_DepartmentID != value)
                {
                    OnDepartmentIDChanging(value);
                    ReportPropertyChanging("DepartmentID");
                    _DepartmentID = StructuralObject.SetValidValue(value, "DepartmentID");
                    ReportPropertyChanged("DepartmentID");
                    OnDepartmentIDChanged();
                }
            }
        }
        private global::System.Int32 _DepartmentID;
        partial void OnDepartmentIDChanging(global::System.Int32 value);
        partial void OnDepartmentIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String DeptName
        {
            get
            {
                return _DeptName;
            }
            set
            {
                OnDeptNameChanging(value);
                ReportPropertyChanging("DeptName");
                _DeptName = StructuralObject.SetValidValue(value, false, "DeptName");
                ReportPropertyChanged("DeptName");
                OnDeptNameChanged();
            }
        }
        private global::System.String _DeptName;
        partial void OnDeptNameChanging(global::System.String value);
        partial void OnDeptNameChanged();

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PayablesModel", "FK_DepartmentEmployee", "Employee1")]
        public EntityCollection<Employee> Employees
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Employee>("PayablesModel.FK_DepartmentEmployee", "Employee1");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Employee>("PayablesModel.FK_DepartmentEmployee", "Employee1", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PayablesModel", Name="Employee")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Employee : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Employee object.
        /// </summary>
        /// <param name="employeeId">Initial value of the EmployeeId property.</param>
        /// <param name="firstName">Initial value of the FirstName property.</param>
        /// <param name="lastName">Initial value of the LastName property.</param>
        /// <param name="age">Initial value of the Age property.</param>
        /// <param name="departmentID">Initial value of the DepartmentID property.</param>
        public static Employee CreateEmployee(global::System.Int32 employeeId, global::System.String firstName, global::System.String lastName, global::System.Int32 age, global::System.Int32 departmentID)
        {
            Employee employee = new Employee();
            employee.EmployeeId = employeeId;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Age = age;
            employee.DepartmentID = departmentID;
            return employee;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 EmployeeId
        {
            get
            {
                return _EmployeeId;
            }
            set
            {
                if (_EmployeeId != value)
                {
                    OnEmployeeIdChanging(value);
                    ReportPropertyChanging("EmployeeId");
                    _EmployeeId = StructuralObject.SetValidValue(value, "EmployeeId");
                    ReportPropertyChanged("EmployeeId");
                    OnEmployeeIdChanged();
                }
            }
        }
        private global::System.Int32 _EmployeeId;
        partial void OnEmployeeIdChanging(global::System.Int32 value);
        partial void OnEmployeeIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, false, "FirstName");
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }
        private global::System.String _FirstName;
        partial void OnFirstNameChanging(global::System.String value);
        partial void OnFirstNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, false, "LastName");
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }
        private global::System.String _LastName;
        partial void OnLastNameChanging(global::System.String value);
        partial void OnLastNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Age
        {
            get
            {
                return _Age;
            }
            set
            {
                OnAgeChanging(value);
                ReportPropertyChanging("Age");
                _Age = StructuralObject.SetValidValue(value, "Age");
                ReportPropertyChanged("Age");
                OnAgeChanged();
            }
        }
        private global::System.Int32 _Age;
        partial void OnAgeChanging(global::System.Int32 value);
        partial void OnAgeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 DepartmentID
        {
            get
            {
                return _DepartmentID;
            }
            set
            {
                OnDepartmentIDChanging(value);
                ReportPropertyChanging("DepartmentID");
                _DepartmentID = StructuralObject.SetValidValue(value, "DepartmentID");
                ReportPropertyChanged("DepartmentID");
                OnDepartmentIDChanged();
            }
        }
        private global::System.Int32 _DepartmentID;
        partial void OnDepartmentIDChanging(global::System.Int32 value);
        partial void OnDepartmentIDChanged();

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PayablesModel", "FK_DepartmentEmployee", "Department1")]
        public Department Department
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Department>("PayablesModel.FK_DepartmentEmployee", "Department1").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Department>("PayablesModel.FK_DepartmentEmployee", "Department1").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Department> DepartmentReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Department>("PayablesModel.FK_DepartmentEmployee", "Department1");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Department>("PayablesModel.FK_DepartmentEmployee", "Department1", value);
                }
            }
        }

        #endregion

    }

    #endregion

}
