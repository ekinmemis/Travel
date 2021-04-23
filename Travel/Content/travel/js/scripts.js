'use strict';
/**
 * 0. Search
 * 1. Featured Slider
 * 2. Share Posts
 * 3. Grid Masonry - Lists Gallery
 * 4. Footer Slider
 * 5. Header V3
 * 6. Related Posts
 * 7. Increase Post Share
 * 8. Map
 * 9. Titled Gallery
 */
(function ($){

	$(document).ready( function() {

		var $search = $('.search');

		if ($search.length) {
			$('.fa-search', $search).on('click', function () {
				$search.toggleClass('active');
			});
		}

		$(document).on('click', function (event) {
			var $target = $(event.target);

			if (!$target.closest('.header-right').length && $search.hasClass('active')) {
				$search.removeClass('active');
			}
		});

		// 1. Featured Slider
		var $featured = $('#featured-slider'),
			$slider = $('.owl-carousel', $featured);

		if ($featured.length) {
			var $thumbnail = $('.slider-thumbnail'),
				options = $.extend({
					items: 1,
					animateOut: 'fadeOut',
					animateIn: 'fadeIn',
					nav: true,
					navText: ['Prev post', 'Next post'],
					navContainerClass: 'owl-nav col-md-offset-7',
					loop: true,
					mouseDrag: false,
					onInitialized: function () {

						$thumbnail.addClass('active');
						$thumbnail.on('click', function() {
							$('.owl-next', $featured).trigger('click');
						});

					},
					onChanged: function () {
						var $active = $('.active', $featured);

						if ($active.length) {
							var src = $active.next().next().find('.image img').attr('src');

							if (src !=='') {
								$('.image', $thumbnail).css('background-image', 'url('+ src +')');
							}
						}
					}
				}, $featured.data());
			$slider.owlCarousel(options);
		}

		/* End Featured Slider */
		var $featured2 = $('#featured-slider-v2');

		if ($featured2.length) {
			var options = {
				items: 3,
				margin: 30,
				loop: true,
				nav: true,
				navText: ['<i class="icon-arrow-point-to-right"></i>', '<i class="icon-arrow-point-to-right"></i>'],
				onInitialized: function () {
					var $image = $('.image', $featured2).eq(0),
						height = $image.css('padding-top');

					if (height) {
						height = parseInt(height, 10)/2;
					}

					$('.owl-prev, .owl-next', $featured2).css('top', height + 'px');
				},
				responsive: {
					0: {
						items: 1,
						nav: false
					},
					992: {

					}
				}
			};

			if ($featured2.hasClass('slider-1-column')) {
				options = $.extend(options, {
					items: 1,
					margin: 0,
					animateOut: 'fadeOut',
					animateIn: 'fadeIn'
				})
			}
			$('.owl-carousel', $featured2).owlCarousel(options);

		}

		/* Share Posts */
		var $postShareWrap = $('.post-share-wrap');

		if ($postShareWrap.length) {
			var $btnShare = $('.icon-share2', $postShareWrap),
				$postShare = $('.post-share', $postShareWrap);

			$btnShare.on('click', function () {
				$postShare.toggleClass('active');
			});
		}
		/* End Share Posts */

		/* 3. Masonry */
		var $grid = $('.post-grids > .row');

		if ($grid.length && 0) {

			var $images = $('img, iframe', $grid),
				count = 0;

			$.each($images, function () {

				if ($(this).is('img')) {
					var image = new Image();

					image.src = $(this).attr('src');

					image.onload = function () {

						count++;

						if (count === $images.length) {
							$grid.trigger('ready');
						}
					}
				}
				else if ($(this).is('iframe')) {
					$(this).load(function () {
						count++;

						if (count === $images.length) {
							$grid.trigger('ready');
						}
					})
				}

			});
			$grid.on('ready', function () {
				$(this).masonry({
					itemSelector: '.col-md-6'
				})
			})

		}

		var $postsList = $('.post-list');

		$.each($postsList, function() {

			var $self = $(this);

			function init() {
				var height = $('.image', $self).css('padding-bottom'),
					$content = $('.col-md-6', $self).eq(1),
					$theExcerpt = $('.the-excerpt', $self),
					heightContent = $content.height(),
					ww = $(window).width();

				height = parseInt(height, 10);

				$theExcerpt.css({
					'max-height': '',
					'overflow' : ''
				});

				if (ww > 991 && (heightContent > height) && height) {
					var excerptHeight = $theExcerpt.height(),
						detal = heightContent - excerptHeight;

					detal = height - detal;
					$theExcerpt.css({
						'max-height': detal + 'px',
						'overflow' : 'hidden'
					});
				}
			}

			init();

			$(window).on('resize', function () {
				init();
			});
		});
		/* End Masonry */

		/* 4. Footer Slider */
		var $footer = $('#footer'),
			$instagram = $('.footer-instagram', $footer);

		$instagram.owlCarousel({
			items: 6,
			responsive: {
				0: {
					items: 2
				},
				480: {
					items: 4
				},
				768: {
				}
			}
		});

		var $blogPosts = $('.blog-posts');

		if ($blogPosts.length) {
			var $pagination = $('.pagination-wrap');

			if (!$pagination.length) {
				$blogPosts.addClass('hidden-divider');
			}
		}

		/* 5. Header */
		// Header v3
		var $headerV3 = $('.header-v3 .header-top');

		if ($headerV3.length) {
			$headerV3.scrollToFixed();
		}

		/* 6. Related Posts*/
		var $related = $('.related-wrap');

		if ($related.length) {
			$related.owlCarousel({
				items: 2,
				margin: 30,
				nav: true,
				navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
				responsive: {
					0: {
						items: 1
					},
					480: {
						items: 1
					},
					768: {

					}
				}
			});
		}

		// Header Mobile
		var $header = $('#header'),
			$btnMobile = $('.menu-mobile'),
			$nav = $('.navigation', $header);

		$('.menu-item-has-children > a', $header).on('click', function (event) {
			var $parent = $(event.target).closest('.menu-item'),
				ww = $(window).width();

			if (ww <= 991) {
				event.preventDefault();

				$parent.toggleClass('menu-active');
				$('> .sub-menu', $parent).slideToggle(400);
			}
		});
		$btnMobile.on('click', function () {
			$(this).toggleClass('active');
			$nav.slideToggle(400);
		});

		// 7. Increase Number Post Share
		var $post = $('.post-single');

		if ( $post.length) {
			var $wrapShare = $('.kd-sharing-post-social', $post);

			$('>a ', $wrapShare).on('click', function (event) {
				var $self = $(this);

				$.ajax({
					url: SIMPLE_LIFE_URL.admin_url,
					type: 'POST',
					data: {
						action: 'simple_life_increase_number_post_share',
						social: $self.attr('class'),
						post_id: $post.attr('id').split('-')[1]
					},
					success: function (response) {
					}
				})
			});
		}

		// 8. Map Google
		var $maps = $('#map');

		if ($maps.length) {
			if ($maps.data('latlong')) {
				var latlong = $maps.data('latlong');

				if (latlong) {
					latlong = latlong.split(',');

					if (latlong[0]) {
						$maps.data('lat', latlong[0]);
						$maps.data('long', latlong[1]);
					}
				}
			}
			var $information = $('.information', $maps),
				lat = $maps.data('lat') ? $maps.data('lat') : '21.036671',
				long = $maps.data('long') ? $maps.data('long') : '105.835090',
				zoom = $maps.data('zoom') ? $maps.data('zoom') : 15,
				dataMap = {
					zoom     : zoom,
					center   : new google.maps.LatLng(lat, long),
					mapTypeId: google.maps.MapTypeId.ROADMAP,
					mapTypeControlOptions: {
						mapTypeIds: ['roadmap', 'satellite', 'hybrid', 'terrain',
							'styled_map']
					},
					scrollwheel: false,
					styles: [{"featureType":"water","elementType":"geometry","stylers":[{"color":"#e9e9e9"},{"lightness":17}]},{"featureType":"landscape","elementType":"geometry","stylers":[{"color":"#f5f5f5"},{"lightness":20}]},{"featureType":"road.highway","elementType":"geometry.fill","stylers":[{"color":"#ffffff"},{"lightness":17}]},{"featureType":"road.highway","elementType":"geometry.stroke","stylers":[{"color":"#ffffff"},{"lightness":29},{"weight":.2}]},{"featureType":"road.arterial","elementType":"geometry","stylers":[{"color":"#ffffff"},{"lightness":18}]},{"featureType":"road.local","elementType":"geometry","stylers":[{"color":"#ffffff"},{"lightness":16}]},{"featureType":"poi","elementType":"geometry","stylers":[{"color":"#f5f5f5"},{"lightness":21}]},{"featureType":"poi.park","elementType":"geometry","stylers":[{"color":"#dedede"},{"lightness":21}]},{"elementType":"labels.text.stroke","stylers":[{"visibility":"on"},{"color":"#ffffff"},{"lightness":16}]},{"elementType":"labels.text.fill","stylers":[{"saturation":36},{"color":"#333333"},{"lightness":40}]},{"elementType":"labels.icon","stylers":[{"visibility":"off"}]},{"featureType":"transit","elementType":"geometry","stylers":[{"color":"#f2f2f2"},{"lightness":19}]},{"featureType":"administrative","elementType":"geometry.fill","stylers":[{"color":"#fefefe"},{"lightness":20}]},{"featureType":"administrative","elementType":"geometry.stroke","stylers":[{"color":"#fefefe"},{"lightness":17},{"weight":1.2}]}]
				},
				map = new google.maps.Map($maps[0], dataMap),
				marker = new google.maps.Marker({
					position: new google.maps.LatLng(lat, long),
					map: map
				});

			if ($information.length) {
				var infoWindow = new google.maps.InfoWindow({
						content: $information.html()
					}),
					isOpen = false;

				marker.addListener('click', function() {
					if (isOpen) {
						infoWindow.close();
						isOpen = false;
					}
					else {
						infoWindow.open(map, marker);
						isOpen = true
					}
				});

				new google.maps.event.trigger( marker, 'click' );
			}


		}

		// 9. Tiled Gallery
		// Tiled Gallery
		var $tiledGallery = $('.images-tiled'),
			$slideShow = $('.images-slides');

		if ($tiledGallery.length) {


			$tiledGallery.each(function () {

				var w = $(this).width(),
					rowHeight = 160;

				if (w > 700) {
					rowHeight = 160;
				}
				else if (w > 400) {
					rowHeight = 100;
				}
				else {
					rowHeight = 80;
				}
				$(this).justifiedGallery({
					rowHeight: rowHeight,
					lastRow  : 'justify',
					margins  : 4,
					randomize: true,
					captions : false
				}).magnificPopup({
					delegate : 'a',
					type     : 'image',
					tLoading : 'Loading image #%curr%...',
					mainClass: 'mfp-img-mobile',
					gallery  : {
						enabled           : true,
						navigateByImgClick: true,
						preload           : [0, 1]
					},
					image    : {
						tError  : '<a href="%url%">The image #%curr%</a> could not be loaded.',
						titleSrc: function (item) {
							return item.el.attr('data-caption');
						}
					}
				})
			});
		}

		if ($slideShow.length) {
			$slideShow.owlCarousel({
				items     : 1,
				loop      : false,
				nav       : false,
				dot: true,
				smartSpeed: 800,
				navText   : ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>']
			});
		}

	});

	$(window).load( function () {
		var $preloader = $('.preloader');

		if ($preloader.length) {
			$preloader.addClass('preloader-hidden');
		}
	})

})(jQuery);