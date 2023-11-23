<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="SGICUwebApp.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Admin</title>

    <script type="text/javascript">
        function ConfirmerEffacer() {

            return confirm("Etes vous sûr de vouloir supprimer ce cours ?");

        }

    </script>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 854px;
        }

       
        #grandTableau{
            width: 700px;
            margin: auto;
            border-radius: 5px;
            font-weight: bold;
            padding: 2px;
            border-spacing: 4px;
            background-color: darkturquoise;
        }
        .boite{
            font-weight: bold;
            border-radius: 3px;
            width: 190px;
            color: brown;
        }
        .button{
            font-weight: bold;
            border-radius: 5px;
            width: 130px;
            color: black;
        }


        
        
    
        .auto-style3 {
            font-weight: bold;
            border-radius: 3px;
            color: brown;
        }
        .auto-style4 {
            width: 188px;
        }
        .auto-style5 {
            width: 59px;
        }
        .auto-style6 {
            height: 27px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <h1><strong>GESTION DES COURS ET PROGRAMME</strong></h1></div>
            <hr class="auto-style2" />
            <br />

            <table id="grandTableau">
                <tr>
                    
                    <td>
                        
                        <fieldset>
                            <legend>Informations du Cours</legend>

                            <table id="petitTableau" class="auto-style2">
                                
                                <tr>
                                    <td><asp:Label ID="lblNumero0" runat="server" Text="Numero : "></asp:Label></td> 
                                    
                                    <td  class="auto-style4">
                                        <asp:TextBox ID="txtNumero" runat="server" CssClass="auto-style3" Width="222px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style5"> 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumero" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAjouter" runat="server"  Text="Ajouter" CssClass="button" OnClick="btnAjouter_Click"  />
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td><asp:Label ID="lblTitre" runat="server" Text="Titre :"></asp:Label></td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtTitre" runat="server"  CssClass="auto-style3" Width="220px" ></asp:TextBox>
                                    </td>

                                    <td class="auto-style5"> 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitre" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnModifier" runat="server"  Text="Modifier" CssClass="button"  style="height: 29px"  />
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        <asp:Label ID="lblProfesseur" runat="server" Text="Enseignant : "></asp:Label>
                                    </td>
                                    <td class="auto-style4">
                                        <asp:DropDownList ID="listenseignant" runat="server" AutoPostBack="True" DataSourceID="listeProfesseurs" DataTextField="nom" DataValueField="Id" Width="227px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="listeProfesseurs" runat="server" ConnectionString="<%$ ConnectionStrings:sgicuConnectionString %>" SelectCommand="SELECT [nom], [Id] FROM [Professeurs]"></asp:SqlDataSource>
                                    </td>
                                    <td class="auto-style5"> 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="listenseignant" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSupprimer" runat="server"  Text="Supprimer" CssClass="button"  OnClientClick="return ConfirmerEffacer();"  />
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style6">
                                        Ce cours a t-il un prérequis ? 
                                    </td>
                                    
                                     <td>
                                         <asp:RadioButtonList ID="radList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="radList_SelectedIndexChanged">
                                             <asp:ListItem>Oui</asp:ListItem>
                                             <asp:ListItem Selected="True">Non</asp:ListItem>
                                         </asp:RadioButtonList>
                                         </td>
                                    
                                     

                                </tr>
                                
                                <tr>
                                    <td>
                                        Prérequis

                                    </td>
                                    <td class="auto-style4">
                                        <asp:DropDownList ID="lstcoursPreq" runat="server" AutoPostBack="True" DataSourceID="listePrerequis" DataTextField="titre" DataValueField="numcours" Width="228px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="listePrerequis" runat="server" ConnectionString="<%$ ConnectionStrings:sgicuConnectionString %>" SelectCommand="SELECT [numcours], [titre] FROM [Cours]"></asp:SqlDataSource>
                                    </td>
                                    
                                </tr>
                                
                                <tr>
                                    <td>
                                        Session

                                    </td>
                                    <td class="auto-style4">


                                        <asp:DropDownList ID="listSession" runat="server" AutoPostBack="True">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                        </asp:DropDownList>


                                    </td>
                                    <td class="auto-style5"> 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="listSession" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" CssClass="button"/>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        Programme

                                    </td>
                                    <td  class="auto-style4">


                                        

                                        <asp:DropDownList ID="lstProgrammes" runat="server" AutoPostBack="True" DataSourceID="listeProgrammes" DataTextField="nom" DataValueField="IdProgramme" Width="231px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="listeProgrammes" runat="server" ConnectionString="<%$ ConnectionStrings:sgicuConnectionString %>" SelectCommand="SELECT [nom], [IdProgramme] FROM [Programme]"></asp:SqlDataSource>


                                        

                                    </td>
                                    <td class="auto-style5"> 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="lstProgrammes" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td>
                                        Nombre heures
                                    </td>
                                    <td class="auto-style4">
                                        
                                        <asp:TextBox ID="txtHeures" runat="server"  CssClass="auto-style3" Width="100px" ></asp:TextBox>
                                    </td>

                                     <td class="auto-style5">
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtHeures" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>

                                   
                                </tr>
                                 <tr>
                                    <td>
                                        Description
                                    </td>
                                    <td class="auto-style4">
                                        
                                        <asp:TextBox ID="txtDesc" runat="server" Rows="3" Columns="22"></asp:TextBox>
                                    </td>

                                     <td class="auto-style5">
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDesc" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                     </td>
                                   
                                </tr>
                                

                            </table>

                        </fieldset>                       

                    </td>
                </tr>
                <tr>

                    <td colspan="3">   <asp:Label ID="lblErreur" runat="server" Text="Label" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                </tr>
               


            </table>

        </div>
        
    
    
    </form>
</body>
</html>
