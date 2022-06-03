<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartFridge.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <header id ="header" class="header">
        <div class="title">
        <span class="title1"> SmartFridge</span>
        </div>
         </header>
        <aside id="sidebar" class="sidebar">
            <ul class="sidebar-nav" id="sidebar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="https://developer.tibber.com/"></a>
                    <span>Dashboard</span>
                </li>
            </ul>
        </aside>
        <main id="main" class="main"></main>
        <section class="section dashboard"></section>
        <div class="card">
            <div class="body">
                    <h1 class="FridgeCode">
                "Fridge Code "
                    <span> | Today</span>
                </h1>
            </div>
        </div>
        
    </form>
</body>
</html>
