<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newProducts.aspx.cs" Inherits="WcfService2.account.newProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
		<link href="jquery-mobile/jquery.mobile.theme-1.0.min.css" rel="stylesheet" type="text/css">
		<link href="jquery-mobile/jquery.mobile.structure-1.0.min.css" rel="stylesheet" type="text/css" />
		<script src="jquery-mobile/jquery-1.6.4.min.js" type="text/javascript"></script>
		<script src="jquery-mobile/jquery.mobile-1.0.min.js" type="text/javascript"></script> 	
		<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.js"></script> 
		<script src="http://malsup.github.com/jquery.form.js"></script> 		

<script type='text/javascript'>

    $(window).load(function () {
        var check = true;
        var toHtml;
        $('.list').live('click', function () {

            myUpc = $(upc).val();
            //073852096521
            $.get("http://api.v3.factual.com/t/products-cpg?q=" + myUpc + "&KEY=orakiImWdD901nYU6jYhOpmdC0FghZ1VM3IkZspF")
            .success(function (s) {
                $(".gift").empty();
                var api = JSON.stringify(s);   // converts json string to json object		
                //alert(api);
                //alert(api[0]);
                var apiObj = JSON && JSON.parse(api) || $.parseJSON(api);  	// for browser compatibility	
                if (apiObj.response.data[0] == undefined) {
                    alert("Please recheck the upc, no results are found.");
                    location.href = "newProducts.aspx";
                }
                var productName = apiObj.response.data[0].brand + " " + apiObj.response.data[0].product_name;
                if (apiObj.response.data[0].avg_price == undefined)
                    var productPrice= "n/a";
                else
                    var productPrice = apiObj.response.data[0].avg_price;

                if (apiObj.response.data[0].image_urls == undefined)
                    var productImage = "n/a";
                else
                    var productImage = apiObj.response.data[0].image_urls[0];

                var productBoughtStatus = false;
                var thisUser = ($('#lbl span').text());
                var registryType = "default";
                //var thisUser = $("#lblName").val();
                //alert(thisUser);
                var newProduct = {
                    name: productName,
                    price: productPrice,
                    boughtStatus: productBoughtStatus,
                    lastName: thisUser,
                    registryType: registryType
                };
                alert(productName);
                $(".gift").append("<p>Product successfully added to registry: " + productName + "<br/>"
                                    + "Average Price: " + productPrice + "<br/>"
                                    + "<img src=" + productImage + "><br/></p>");	//writing to html

                $.ajax({
                    type: 'POST',
                    url: '/aspnet_client/WcfService2/WcfService2/Service1.svc/addProduct',
                    data: JSON.stringify({ product: newProduct }),
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',

                    success: function (data) {
                        location.href = "newProducts.aspx";
                        $('#results').html("Product Name: " + data.NewProduct.name + " <br/> Product Price: " + data.NewProduct.boughtStatus);
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        alert(window.location.pathname);
                        alert(textStatus + "      " + errorThrown);
                    }
                });
            })
            .error(function (jqXHR, textStatus, errorThrown) {
                alert('UPC error. Please check to ensure you entered a valid UPC.');
                location.href = "newProducts.aspx";
            });
        });
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<!--<div data-role="page" id="page1" data-theme="c">-->
  <div data-role="header">
              <div id="lbl">
    <h1>

<asp:Label ID="lblName" runat="server" Text=""></asp:Label>

        , Add Products</h1>
         </div>
      <a href="main.aspx">back to home page</a>
  </div>
	<div data-role="content">
		<div data-role="fieldcontain">    
			<p>
				<label for="upc">
					Please Enter Your Product's serial number
				</label>
				<input placeholder="UPC Number here" type="text" name="upc" id="upc" value="" />
			</p>
		  <p>
		   <input type="submit" name="submit" class = "list" value="Add to registry" />
		  </p>
		</div>
		<div class="gift">
		</div>		
	</div>
</div>    
    <!--</div>-->
    </form>
</body>
</html>
