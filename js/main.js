(function($) {

	"use strict";

	var fullHeight = function() {

		$('.js-fullheight').css('height', $(window).height());
		$(window).resize(function(){
			$('.js-fullheight').css('height', $(window).height());
		});

	};
	fullHeight();

	$('#sidebarCollapse').on('click', function () {
      $('#sidebar').toggleClass('active');
  });

})(jQuery);



async function cerrarsesion() {
	await fetch('Profile.aspx/cerrarsesion', {

		method: 'POST', // or 'PUT'
		headers: {
			'Content-Type': 'application/json',
		},
		

	})
		.catch(error => console.error('Error:', error))
	window.location.href = "Login.aspx";
}