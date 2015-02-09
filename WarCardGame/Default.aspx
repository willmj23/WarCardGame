<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WarCardGame.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Button ID="btnCreateDeck" runat="server" Text="Create Deck" />
        <asp:Button ID="btnShuffle" runat="server" Visible="false" Text="Shuffle" />
<asp:Button ID="btnDeal" runat="server" Visible="false" Text="Deal" />
        <asp:Button ID="btnFight" runat="server" Visible="false" Text="Begin Game" />
        <hr />
        <asp:Panel ID="pnlDeck" runat="server" Visible="false">

            <table cellpadding="1" cellspacing="1" border="1">
                <tr runat="server" id="trTeam1" visible="false">
                    <td><h1>Team 1 Deck</h1></td>
                </tr>
                <tr>
                    <td>
                        <asp:Repeater ID="rptTeam1Decka" runat="server">
                            <ItemTemplate>
                                <asp:Image ID="img1" runat="server" Width="70px" />
                            </ItemTemplate>
                        </asp:Repeater></td>
                </tr>
                <tr>
                    <td>
                        <asp:Repeater ID="rptTeam1Deckb" runat="server">
                            <ItemTemplate>
                                <asp:Image ID="img1" runat="server" Width="70px" />
                            </ItemTemplate>
                        </asp:Repeater></td>
                </tr>
                <tr runat="server" id="trTeam2" visible="false">
                    <td><h1>Team 2 Deck</h1></td>
                </tr>
                <tr>
                    <td>
                        <asp:Repeater ID="rptTeam2Decka" runat="server">
                            <ItemTemplate>
                                <asp:Image ID="img1" runat="server" Width="70px" />
                            </ItemTemplate>
                        </asp:Repeater></td>
                </tr>
                <tr>
                    <td>
                        <asp:Repeater ID="rptTeam2Deckb" runat="server">
                            <ItemTemplate>
                                <asp:Image ID="img1" runat="server" Width="70px" />
                            </ItemTemplate>
                        </asp:Repeater></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
