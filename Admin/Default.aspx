<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.js"></script>
    <script src="/assets/js/AdminCharts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
        <div style="width: 600px; margin: auto;">
            <canvas id="ordersChart" runat="server" class="order-chart chart" data-chart-label="Number of orders in past 6 months" data-chart-color="rgba(255,99,132,1)"></canvas>
            <canvas id="salesChart" runat="server" class="sale-chart chart" data-chart-label="Amount of Revenue in past 6 months" data-chart-yaxis-tick="£" data-chart-color="rgba(132,99,255,1)"></canvas>
        </div>
    </form>
</asp:Content>

