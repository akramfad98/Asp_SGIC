<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="etudiant.aspx.cs" Inherits="SGICUwebApp.etudiant" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestion de cours</title>
    <style type="text/css">
        body {
            font-family: 'Segoe UI', Arial, sans-serif;
            background-color: #f4f4f4;
            color: #333;
            margin: 0;
            padding: 0;
        }

        .container {
            width: 90%;
            max-width: 1200px;
            margin: auto;
            padding: 20px;
        }

        h1, h2 {
            text-align: center;
            color: #333;
        }

        .box {
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.2);
            padding: 20px;
            margin-bottom: 20px;
        }

        .flex-row {
            display: flex;
            justify-content: space-between;
            align-items: flex-start;
        }

        .flex-row > div {
            flex: 1;
            margin-right: 20px;
        }

        .flex-row > div:last-child {
            margin-right: 0;
        }

        .data-list, .grid-view {
            width: 100%;
            border-collapse: collapse;
        }

        .data-list th, .data-list td, .grid-view th, .grid-view td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        .data-list th, .grid-view th {
            background-color: #007bff;
            color: white;
        }

        .data-list tr:nth-child(even), .grid-view tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .button {
            background-color: #007bff;
            color: white;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s;
            margin-left: 10px;
        }

        .button {
            background-color: #007bff;
            color: white;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s;
            
        }

        .button:hover {
            background-color: #0056b3;
            
        }

        .list-box {
    width: 100%;
    padding: 10px;
    margin-top: 15px;
    border: 1px solid #ddd;
    border-radius: 5px;
    background-color: white;
}

    </style>

    <script type="text/javascript">
        function ConfirmerAbandonner() {

            return confirm("Etes vous sûr de vouloir abondonner ce cours ?");

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Gestion Des Cours</h1>
            <hr />
            <h2>Bienvenu <asp:Label ID="lblWlcm" runat="server" Text="" Font-Bold="True"></asp:Label></h2>
            <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>

            <div class="flex-row">
                <div class="box">
                    Choisir un Cours<br />
                    <asp:ListBox ID="lstCours" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstCours_SelectedIndexChanged" DataTextField="titre" DataValueField="numcours"></asp:ListBox>
                </div>
                <div class="box">
                    Informations du Cours
                    <asp:DataList ID="infoCours" runat="server">
                        <ItemTemplate>
                            Num Cours: <%# Eval("NumCours") %><br />
                            Titre: <%# Eval("Titre") %><br />
                            Programme: <%# Eval("ProgrammeName") %><br />
                            Prerequis: <%# Eval("Prerequis") %><br />
                            Session: <%# Eval("Session") %><br />
                            Heures: <%# Eval("Heures") %><br />
                            Description: <%# Eval("Description") %><br />
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                 <br />   
                <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" CssClass="button" OnClick="btnAjouter_Click" /> 
               <asp:Button ID="btnAbandonner" runat="server" Text="Abandonner" CssClass="button" OnClientClick="return ConfirmerAbandonner();" OnClick="btnAbandonner_Click" />

                <br />   
            </div>

             <br />
                <asp:Label ID="lblError" runat="server" Text="" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>

                <br />

            <div class="box">

                
                

                <asp:Label ID="lblGridViewHeader" runat="server" Text="Cours Validés" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:GridView ID="coursValide" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="NumCours" HeaderText="Num Cours" />
                        <asp:BoundField DataField="Titre" HeaderText="Titre" />
                        <asp:BoundField DataField="ProgrammeName" HeaderText="Programme" />
                        <asp:BoundField DataField="Prerequis" HeaderText="Prerequis" />
                        <asp:BoundField DataField="Session" HeaderText="Session" />
                        <asp:BoundField DataField="Heures" HeaderText="Heures" />
                        <asp:BoundField DataField="Desc" HeaderText="Description" />
                    </Columns>
                </asp:GridView>

                <h3>Mes Cours de la session </h3>
                <asp:ListBox ID="lstMesCours" runat="server" CssClass="list-box" AutoPostBack="True" OnSelectedIndexChanged="lstMesCours_SelectedIndexChanged"></asp:ListBox>
            </div>
        </div>
        <asp:Button ID="btnLogout" runat="server" Text="Quitter" CssClass="button" OnClick="btnLogout_Click"  />
    </form>
</body>
</html>

