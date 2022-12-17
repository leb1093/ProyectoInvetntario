<%@ Page Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="Graficas.aspx.cs" Inherits="ApliciacionInventario.Graficas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
        <script type="text/javascript">

            // Load the Visualization API and the corechart package.
            google.charts.load('current', { 'packages': ['corechart'] });

            // Set a callback to run when the Google Visualization API is loaded.
            google.charts.setOnLoadCallback(drawChart);
            google.charts.setOnLoadCallback(drawChart2);
            google.charts.setOnLoadCallback(drawChart3);
            google.charts.setOnLoadCallback(drawChart4);
            google.charts.setOnLoadCallback(drawChart5);
            google.charts.setOnLoadCallback(drawChart6);
            google.charts.setOnLoadCallback(drawChart7);
            google.charts.setOnLoadCallback(drawChart8);
            google.charts.setOnLoadCallback(drawChart9);
            google.charts.setOnLoadCallback(drawChart10);
            google.charts.setOnLoadCallback(drawChart11);
            google.charts.setOnLoadCallback(drawChart12);
            // Callback that creates and populates a data table,
            // instantiates the pie chart, passes in the data and
            // draws it.
            function drawChart() {
                debugger;
                // Create the data table.
                var data = new google.visualization.DataTable();
                data.addColumn('string', 'Topping');
                data.addColumn('number', 'Slices');
                data.addRows(<%=CargarGraficas1()%>);

                // Set chart options
                var options = {
                    'title': 'ESTADO',
                    'width': 400,
                    'height': 400,
                    pieHole: 0.4,
                    "backgroundColor": { "fill": "#a8a2e8" },
                };

                // Instantiate and draw our chart, passing in some options.
                var chart = new google.visualization.PieChart(document.getElementById('chart_div2'));
                chart.draw(data, options);
            }

            function drawChart2() {
                var data = google.visualization.arrayToDataTable(<%=CargarGraficas2()%>);

                var view = new google.visualization.DataView(data);
                view.setColumns([0, 1,
                    {
                        calc: "stringify",
                        sourceColumn: 1,
                        type: "string",
                        role: "annotation",
                        "backgroundColor": { "fill": "#b72c2c" },
                    },
                    2]);

                var options = {
                    title: "TIPO DE TECNOLOGIA",
                    width: 400,
                    height: 400,
                    "backgroundColor": { "fill": "#a8a2e8" },
                    bar: { groupWidth: "60%" },
                    legend: { position: "none" },

                };
                var chart = new google.visualization.ColumnChart(document.getElementById("columnchart_values2"));
                chart.draw(view, options);
            }
            function drawChart3() {
                var data = google.visualization.arrayToDataTable(<%=CargarGraficas3()%>);

                var view = new google.visualization.DataView(data);
                view.setColumns([0, 1,
                    {
                        calc: "stringify",
                        sourceColumn: 1,
                        type: "string",
                        role: "annotation"
                    },
                    2]);

                var options = {
                    title: "MARCAS",
                    width: 400,
                    height: 400,
                    bar: { groupWidth: "60%" },
                    legend: { position: "none" },
                    "backgroundColor": { "fill": "#a8a2e8" },
                };
                var chart = new google.visualization.BarChart(document.getElementById("barchart_values2"));
                chart.draw(view, options);
            }
            
            
            //-----------------------------------------------------

            function drawChart4() {
                debugger;
                // Create the data table.
                var data = new google.visualization.DataTable();
                data.addColumn('string', 'Topping');
                data.addColumn('number', 'Slices');
                data.addRows(<%=CargarGraficas4()%>);

                // Set chart options
                var options = {
                    'title': 'ESTADO',
                    'width': 400,
                    'height': 400,
                    pieHole: 0.4,
                    "backgroundColor": { "fill": "#6be2a9" },
                };

                // Instantiate and draw our chart, passing in some options.
                var chart = new google.visualization.PieChart(document.getElementById('chart_div3'));
                chart.draw(data, options);
            }

            function drawChart5() {
                var data = google.visualization.arrayToDataTable(<%=CargarGraficas5()%>);

                var view = new google.visualization.DataView(data);
                view.setColumns([0, 1,
                    {
                        calc: "stringify",
                        sourceColumn: 1,
                        type: "string",
                        role: "annotation"
                    },
                    2]);

                var options = {
                    title: "TIPO DE TECNOLOGIA",
                    width: 400,
                    height: 400,
                    bar: { groupWidth: "60%" },
                    legend: { position: "none" },
                    "backgroundColor": { "fill": "#6be2a9" },
                };
                var chart = new google.visualization.ColumnChart(document.getElementById("columnchart_values3"));
                chart.draw(view, options);
            }
            function drawChart6() {
                var data = google.visualization.arrayToDataTable(<%=CargarGraficas6()%>);

                var view = new google.visualization.DataView(data);
                view.setColumns([0, 1,
                    {
                        calc: "stringify",
                        sourceColumn: 1,
                        type: "string",
                        role: "annotation"
                    },
                    2]);

                var options = {
                    title: "MARCAS",
                    width: 400,
                    height: 400,
                    bar: { groupWidth: "60%" },
                    legend: { position: "none" },
                    "backgroundColor": { "fill": "#6be2a9" },
                };
                var chart = new google.visualization.BarChart(document.getElementById("barchart_values3"));
                chart.draw(view, options);
            }
            
            //---------------------------------------------------------------------

            function drawChart7() {
                debugger;
                // Create the data table.
                var data = new google.visualization.DataTable();
                data.addColumn('string', 'Topping');
                data.addColumn('number', 'Slices');
                data.addRows(<%=CargarGraficas7()%>);

                // Set chart options
                var options = {
                    'title': 'ESTADO',
                    'width': 400,
                    'height': 400,
                    pieHole: 0.4,
                    "backgroundColor": { "fill": "#ea7373" },
                };

                // Instantiate and draw our chart, passing in some options.
                var chart = new google.visualization.PieChart(document.getElementById('chart_div4'));
                chart.draw(data, options);
            }

            function drawChart8() {
                var data = google.visualization.arrayToDataTable(<%=CargarGraficas8()%>);

                var view = new google.visualization.DataView(data);
                view.setColumns([0, 1,
                    {
                        calc: "stringify",
                        sourceColumn: 1,
                        type: "string",
                        role: "annotation"
                    },
                    2]);

                var options = {
                    title: "TIPO DE TECNOLOGIA",
                    width: 400,
                    height: 400,
                    bar: { groupWidth: "60%" },
                    legend: { position: "none" },
                    "backgroundColor": { "fill": "#ea7373" },
                };
                var chart = new google.visualization.ColumnChart(document.getElementById("columnchart_values4"));
                chart.draw(view, options);
            }
            function drawChart9() {
                var data = google.visualization.arrayToDataTable(<%=CargarGraficas9()%>);

                var view = new google.visualization.DataView(data);
                view.setColumns([0, 1,
                    {
                        calc: "stringify",
                        sourceColumn: 1,
                        type: "string",
                        role: "annotation"
                    },
                    2]);

                var options = {
                    title: "MARCAS",
                    width: 400,
                    height: 400,
                    bar: { groupWidth: "60%" },
                    legend: { position: "none" },
                    "backgroundColor": { "fill": "#ea7373" },
                };
                var chart = new google.visualization.BarChart(document.getElementById("barchart_values4"));
                chart.draw(view, options);
            }

            //-----------------------------------------------------------------------------
            function drawChart10() {
                debugger;
                // Create the data table.
                var data = new google.visualization.DataTable();
                data.addColumn('string', 'Topping');
                data.addColumn('number', 'Slices');
                data.addRows(<%=CargarGraficas10()%>);

                // Set chart options
                var options = {
                    'title': 'ESTADO',
                    'width': 400,
                    'height': 400,
                    pieHole: 0.4,
                    is3D: true
                };

                // Instantiate and draw our chart, passing in some options.
                var chart = new google.visualization.PieChart(document.getElementById('chart_div1'));
                chart.draw(data, options);
            }

            function drawChart11() {
                var data = google.visualization.arrayToDataTable(<%=CargarGraficas11()%>);

                var view = new google.visualization.DataView(data);
                view.setColumns([0, 1,
                    {
                        calc: "stringify",
                        sourceColumn: 1,
                        type: "string",
                        role: "annotation"
                    },
                    2]);

                var options = {
                    title: "TIPO DE TECNOLOGIA",
                    width: 400,
                    height: 400,
                    bar: { groupWidth: "60%" },
                    legend: { position: "none" },
                };
                var chart = new google.visualization.ColumnChart(document.getElementById("columnchart_values1"));
                chart.draw(view, options);
            }
            function drawChart12() {
                var data = google.visualization.arrayToDataTable(<%=CargarGraficas12()%>);

                var view = new google.visualization.DataView(data);
                view.setColumns([0, 1,
                    {
                        calc: "stringify",
                        sourceColumn: 1,
                        type: "string",
                        role: "annotation"
                    },
                    2]);

                var options = {
                    title: "MARCAS",
                    width: 400,
                    height: 400,
                    bar: { groupWidth: "60%" },
                    legend: { position: "none" },
                };
                var chart = new google.visualization.BarChart(document.getElementById("barchart_values1"));
                chart.draw(view, options);
            }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row border border-warning rounded">
        <h1>General</h1>
        <div id="chart_div1" class="col col-sm4 "></div>
        <div id="columnchart_values1" class="col col-sm4" style="width: 900px; height: 300px;"></div>
        <div id="barchart_values1" class="col col-sm4" style="width: 900px; height: 300px;"></div>
        </div>
    <br />
    <br />
        <div class="row border border-primary rounded">
        <h1>Hangar</h1>
        <div id="chart_div2" class="col col-sm4"></div>
        <div id="columnchart_values2" class="col col-sm4" style="width: 900px; height: 300px;"></div>
        <div id="barchart_values2" class="col col-sm4" style="width: 900px; height: 300px;"></div>
            </div>
        <br />
    <br />
            <div class="row border border-success rounded">
        <h1>ATO</h1>
        <div id="chart_div3" class="col col-sm4"></div>
        <div id="columnchart_values3" class="col col-sm4" style="width: 900px; height: 300px;"></div>
        <div id="barchart_values3" class="col col-sm4" style="width: 900px; height: 300px;"></div>
                </div>
        <br />
    <br />
                <div class="row border border-danger rounded">
        <h1>Plaza Latam</h1>
        <div id="chart_div4" class="col col-sm4"></div>
        <div id="columnchart_values4" class="col col-sm4" style="width: 900px; height: 300px;"></div>
        <div id="barchart_values4" class="col col-sm4" style="width: 900px; height: 300px;"></div>
    </div>
    
</asp:Content>


