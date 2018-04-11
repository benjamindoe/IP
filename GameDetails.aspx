<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="GameDetails.aspx.cs" Inherits="GameDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form runat="server" id="form1">
        <div class="gamepage-game">
            <asp:HiddenField runat="server" ID="hdnID"/>
            <asp:HiddenField runat="server" ID="hdnTitle"/>
            <asp:HiddenField runat="server" ID="hdnDescription"/>
            <asp:HiddenField runat="server" ID="hdnPrice"/>
            <asp:HiddenField runat="server" ID="hdnImage"/>
            <div class="left-col">
                <img src="/" class="game-image" id="GameImage" runat="server"/>
            </div>
            <div class="right-col">
                <h2 runat="server" id="GameTitle"></h2>
                <div class="avg-star-rating" runat="server" id="avgRating">
                    <span runat="server" ID="star1" class="star"><i class="material-icons">star_border</i></span>
                    <span runat="server" ID="star2" class="star"><i class="material-icons">star_border</i></span>
                    <span runat="server" ID="star3" class="star"><i class="material-icons">star_border</i></span>
                    <span runat="server" ID="star4" class="star"><i class="material-icons">star_border</i></span>
                    <span runat="server" ID="star5" class="star"><i class="material-icons">star_border</i></span>
                </div>
                <p runat="server" id="GameDesc" class="game-description"></p>
                <div class="price-area">
                    <p class="price-area_price">
                        Price: <span runat="server" id="GamePrice" class=""></span>
                    </p>
                    <asp:Button Text="ADD TO BASKET" id="btnAddBasket" runat="server" OnClick="btnAddBasket_Click" class="btn btn-add-basket" />
                </div>
            </div>
            <div class="game-review-area">
                <h2>Customer Reviews</h2>
                <div class="user-rating" runat="server" id="userRating">
                    <div class="star-rating">
                        <span data-star="1" class="star star-1"><i class="material-icons">star_border</i></span>
                        <span data-star="2" class="star star-2"><i class="material-icons">star_border</i></span>
                        <span data-star="3" class="star star-3"><i class="material-icons">star_border</i></span>
                        <span data-star="4" class="star star-4"><i class="material-icons">star_border</i></span>
                        <span data-star="5" class="star star-5"><i class="material-icons">star_border</i></span>
                        <asp:HiddenField runat="server" ID="hdnStarRating"/>
                    </div>
                    <asp:TextBox runat="server" ID="txtReviewComment" Rows="5" Columns="50" TextMode="MultiLine"/>
                    <asp:Button Text="Write Review" ID="btnWriteReview" runat="server" OnClick="btnWriteReview_Click" />
                </div>
                <div class="game-comments" runat="server" id="gameComments"></div>
            </div>
            <script>
                $(function () {
                    var $stars = $('.star-rating .star')
                    $stars.hover(function () {
                        fillStars($(this).data('star'), 'grey');
                    }, function () {
                        fillStars($stars.siblings('input').val());
                    });
                    $stars.click(function () {
                        $(this).parent().find('input').val($(this).data('star'));
                        fillStars($(this).data('star'));
                    });
                });
                function fillStars(num, color = 'gold') {
                    var $stars = $('.star-rating .star');
                    $stars.find('.material-icons').text('star_border');
                    $stars.css("color", "");
                    for (var i = 1; i <= num; i++) {
                        var $star = $('.star-rating .star-' + i);
                        $star.find('.material-icons').text('star');
                        $star.css("color", color);
                    }
                }
            </script>
        </div>
    </form>
</asp:Content>

