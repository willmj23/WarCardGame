<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb"  Inherits="WarCardGame.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        Rules:
        <asp:DropDownList ID="ddlRules" runat="server">
            <asp:ListItem Text="Classic Rules" Value="1"></asp:ListItem>
                 <asp:ListItem Text="Opposite Rules" Value="2"></asp:ListItem>
        </asp:DropDownList><br />
        <asp:Button ID="btnStart" runat="server" Text="Start Game" />
          
        <hr />
        <asp:Panel ID="pnlResults" runat="server" Visible="false">
            <h2>Results: 
                <asp:Literal ID="ltlResults" runat="server"></asp:Literal></h2>
            Team1 Score:
            <asp:Literal ID="ltlTeam1Score" runat="server"></asp:Literal><br />
            Team2 Score:
            <asp:Literal ID="ltlTeam2Score" runat="server"></asp:Literal><br />
            Ties:
            <asp:Literal ID="ltlties" runat="server"></asp:Literal><br />

            <h3>Detailed Results</h3>
            <table cellpadding="1" cellspacing="1" border="1">
                <tr>
                    <td><strong>Team1 Card</strong> </td>
                    <td>&nbsp;</td>
                    <td><strong>Team 2 Card</strong></td>
                    <td><strong>Result</strong></td>
                </tr>
                <asp:Repeater ID="rptResults" runat="server">
                    <ItemTemplate>
                        <tr runat="server" id="trResult">
                            <td align="center">
                                <asp:Image ID="imgTeam1" runat="server" Width="100px" /></td>
                            <td align="center">VS</td>
                            <td align="center">
                                <asp:Image ID="imgTeam2" runat="server" Width="100px" /></td>
                            <td>
                                <asp:Literal ID="ltlResult" runat="server"></asp:Literal></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>


        </asp:Panel>

    </div>



</asp:Content>
