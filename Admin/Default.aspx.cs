using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string conStr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();
            string sqlQuery =
                    @"SELECT
                        COUNT([Orders].[id]) AS TotalOrders,
                        SUM([Orders].[subtotal]) AS SumCost,
                        MONTH([Orders].[date]) as Month,
                        DATENAME(month, [Orders].[date]) as MonthName
                    FROM
                        Orders
                    WHERE
                        [Orders].date >= DATEADD(month, -6, GETDATE())
                    GROUP BY
                        MONTH([Orders].[date]), DATENAME(month, [Orders].[date])
                    ORDER BY MONTH([Orders].[date]) DESC;";
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    var historicLimit = 6; //months
                    var monthNames = Enumerable.Range(1, 6).Select(i => DateTime.Now.AddMonths(-i).ToString("MMMM"));
                    var SumOfCosts = new decimal[historicLimit];
                    var totalOrders = new int[historicLimit];
                    var j = historicLimit - 1;
                    while (reader.Read())
                    {
                        totalOrders[j] = (int)reader["TotalOrders"];
                        SumOfCosts[j] = (decimal)reader["SumCost"];
                        j--;
                    }
                    var json = new System.Web.Script.Serialization.JavaScriptSerializer();
                    ordersChart.Attributes.Add("data-chart-labels", json.Serialize(monthNames));
                    salesChart.Attributes.Add("data-chart-labels", json.Serialize(monthNames));
                    ordersChart.Attributes.Add("data-chart-data", json.Serialize(totalOrders));
                    salesChart.Attributes.Add("data-chart-data", json.Serialize(SumOfCosts));

                    string val = monthNames.ToString();
                }
            }

        }
    }
}