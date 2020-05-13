using System;
using System.Collections.Generic;

namespace rating_empresas_api_.NET.Models
{
    public partial class Reviews
    {
        public string Id { get; set; }
        public string User_Id { get; set; }
        public string Position_Id { get; set; }
        public short Start_Year { get; set; }
        public short? End_Year { get; set; }
        public decimal? Salary { get; set; }
        public string Inhouse_Training { get; set; }
        public string Growth_Opportunities { get; set; }
        public string Work_Enviroment { get; set; }
        public string Personal_Life { get; set; }
        public string Salary_Valuation { get; set; }
        public string Comment_Title { get; set; }
        public string Comment { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Deleted_At { get; set; }
        public string City_Id { get; set; }
        public string Company_Id { get; set; }

        public virtual CompaniesCities C { get; set; }
        public virtual Positions Position { get; set; }
        public virtual Users User { get; set; }
    }
}
