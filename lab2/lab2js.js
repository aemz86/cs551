$(document).on("click", ".show-page-loading-msg", function() {
		var $this = $( this ),
			theme = $this.jqmData("theme") || $.mobile.loader.prototype.options.theme,
			msgText = $this.jqmData("msgtext") || $.mobile.loader.prototype.options.text,
			textVisible = $this.jqmData("textvisible") || $.mobile.loader.prototype.options.textVisible,
			textonly = !!$this.jqmData("textonly");
			html = $this.jqmData("html") || "";
			$.mobile.loading( 'show', {
				text: msgText,
				textVisible: textVisible,
				theme: theme,
				textonly: textonly,
				html: html
			});
		})
		.on("click", ".hide-page-loading-msg", function() {
			$.mobile.loading( 'hide' );
		});


$("#ButtonEventPage").on("pageshow",function(e) {
	

	$("#EventButton").on("click", function(e) {
		
		$("#status").html("<p>Loading...</p>");
		console.log("You Get the random number: "+Math.random())
		setTimeout(function() {
			$("#status").html("<p>You Got a random number: "+Math.random() + "</p>");
		},400);
	});


         $("#WelcomeButton").on("click", function(e) {
		
		
		$("#status").html("<p>Welcome to CS551 Class</p>");
		
	});


});



$.ajax({
  url: 'http://api.wunderground.com/api/36b799dc821d5836/conditions/q/MO/Kansas City.json',
  dataType: 'jsonp',
  data: 'url',
  success: function(data) {
    var celsi, index, result, tD, temp, weather, _results;
    _results = [];
    for (index in data) {
      result = data[index];
      temp = Math.round(result.temp_f);
      weather = result.weather;
      celsi = result.temp_c;
      tD = result.observation_time;
      $('p.stlConditions').html("Currently  " + temp + " &deg; F and " + weather);
      $('div.stlCelsius').html("<br/><br/>Temp in Celsius: " + celsi + "&deg;");
      _results.push($('p.stlTimeDate').html("" + tD));
    }
    return _results;
  }
});



$.ajax({
  url: 'http://api.wunderground.com/api/36b799dc821d5836/conditions/q/MO/St%20Louis.json',
  dataType: 'jsonp',
  data: 'url',
  success: function(data) {
    var celsi, index, result, tD, temp, weather, _results;
    _results = [];
    for (index in data) {
      result = data[index];
      temp = Math.round(result.temp_f);
      weather = result.weather;
      celsi = result.temp_c;
      tD = result.observation_time;
      $('p.currentConditions').html("Currently  " + temp + " &deg; F and " + weather);
      $('div.celsius').html("<br/><br/>Temp in Celsius: " + celsi + "&deg;");
      _results.push($('p.timeDate').html("" + tD));
    }
    return _results;
  }
});