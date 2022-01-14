<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Alumil</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta name="author" content="" />

    <!-- Facebook and Twitter integration -->
   

    <link href="https://fonts.googleapis.com/css?family=Quicksand:300,400,500,700" rel="stylesheet" />
    <!-- Place favicon.ico and apple-touch-icon.png in the root directory -->
    <link rel="shortcut icon" href="favicon.ico" />

    <!-- Animate.css -->
    <link rel="stylesheet" href="ocss/animate.css" />
    <!-- Icomoon Icon Fonts-->
    <link rel="stylesheet" href="ocss/icomoon.css" />
    <!-- Bootstrap  -->
    <link rel="stylesheet" href="ocss/bootstrap.css" />
    <!-- Flexslider  -->
    <link rel="stylesheet" href="ocss/flexslider.css" />
    <!-- Flaticons  -->
    <link rel="stylesheet" href="ofonts/flaticon/font/flaticon.css" />
    <!-- Owl Carousel -->
    <link rel="stylesheet" href="ocss/owl.carousel.min.css" />
    <link rel="stylesheet" href="ocss/owl.theme.default.min.css" />
    <!-- Theme style  -->
    <link rel="stylesheet" href="ocss/style.css" />
    <script src="ojs/modernizr-2.6.2.min.js"></script>
    <!-- Modernizr JS -->

    <!-- FOR IE9 below -->
    <!--[if lt IE 9]>
	<script src="js/respond.min.js"></script>
	<![endif]-->

   
</head>
<body>

     

    <div id="colorlib-page">

       <div class="row navbar-fixed-top" style="background-color:#2C2C2C;height:40px">
          
           <a href="Login.aspx" style="margin-left: 92%;color:black" class="btn btn-primary">Login</a>
       </div>

        <aside id="colorlib-aside" role="complementary" class="border js-fullheight">
            <a href="#" class="js-colorlib-nav-toggle colorlib-nav-toggle"><i></i></a>
            <h1 id="colorlib-logo"><a href="index.html">Alumil</a></h1>
          
                <nav id="colorlib-main-menu" role="navigation">
                      <ul>
                    <li class="colorlib-active"><a href="index.html">Home</a></li>

                        

                    <li><a href="#">Our Products</a></li>
                    <li><a href="#">Download Catalog</a></li>
                    <li><a href="#">Projects</a></li>
                    <li><a href="#">Clients</a></li>
                    <li><a href="#">Contact Us</a></li>
            </ul>


                    <ul>
                           <li><a  href="Login.aspx">Login</a></li>
                           <li><a  href="MobileLogin.aspx">Mobile Login</a></li>
                    </ul>

            </nav>
            
			<div class="colorlib-footer">
                <ul>
                    <li><a href="#"><i class="icon-facebook2"></i></a></li>
                    <li><a href="#"><i class="icon-twitter2"></i></a></li>
                    <li><a href="#"><i class="icon-instagram"></i></a></li>5
                    <li><a href="#"><i class="icon-linkedin2"></i></a></li>
                </ul>
            </div>
        </aside>

        <div id="colorlib-main">
            <aside id="colorlib-hero" class="js-fullheight">
                <div class="flexslider js-fullheight">
                    <ul class="slides">
                        <li style="background-image: url(oimg/1.jpg);">
                            <div class="overlay"></div>
                            <div class="container-fluid">
                                <div class="row">
                                    <div class="col-md-6 col-md-offset-3 col-md-push-3 col-sm-12 col-xs-12 js-fullheight slider-text">
                                        <div class="slider-text-inner">
                                            <div class="desc">
                                                <h1>The Company</h1>
                                                <h2>We are thinkers, innovators, creators, designers. We are people who nurture a deep appreciation for art, nature, and aesthetic. We are people with a history of talent and intuition.</h2>
                                                <!--<p><a class="btn btn-primary btn-learn">View Project <i class="icon-arrow-right3"></i></a></p>-->
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li style="background-image: url(oimages/img_bg_1.jpg);">
                            <div class="overlay"></div>
                            <div class="container-fluid">
                                <div class="row">
                                    <div class="col-md-6 col-md-offset-3 col-md-push-3 col-sm-12 col-xs-12 js-fullheight slider-text">
                                        <div class="slider-text-inner">
                                            <div class="desc">
                                                <h1>Our Mission</h1>
                                                <h2>Our mission is to improve the quality of people’s lives by enhancing the performance of their buildings, with products of the highest quality, technology and aesthetics.</h2>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </li>

                        <li style="background-image: url(oimg/3.jpg);">
                            <div class="overlay"></div>
                            <div class="container-fluid">
                                <div class="row">
                                    <div class="col-md-6 col-md-offset-3 col-md-push-3 col-sm-12 col-xs-12 js-fullheight slider-text">
                                        <div class="slider-text-inner">
                                            <div class="desc">
                                                <h1>Our Vision</h1>
                                                <h2>Our vision is to be a leading company in developing and producing aluminium systems for architectural applications.</h2>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li style="background-image: url(oimg/4.jpg);">

                            <div class="overlay"></div>
                            <div class="container-fluid">
                                <div class="row">
                                    <div class="col-md-6 col-md-offset-3 col-md-push-3 col-sm-12 col-xs-12 js-fullheight slider-text">
                                        <div class="slider-text-inner">
                                            <div class="desc">
                                                <h1>Our Values</h1>
                                                <h2>Our values are the essence of our overall business philosophy and reflect the way we approach our customers and stakeholders.</h2>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </aside>

            <div class="colorlib-about">
                <div class="colorlib-narrow-content">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="about-img animate-box" data-animate-effect="fadeInLeft" style="background-image: url(oimages/img-6.jpg);">
                            </div>
                        </div>
                        <div class="col-md-6 animate-box" data-animate-effect="fadeInLeft">
                            <div class="about-desc">
                                <span class="heading-meta">Welcome</span>
                                <h2 class="colorlib-heading">Who we are</h2>
                                <p>We are thinkers, innovators, creators, designers. We are people who nurture a deep appreciation for art, nature, and aesthetic. We are people with a history of talent and intuition.</p>
                                <p>We hope to keep alive this family tradition and the brand, guided by the principles of quality and personality for a long time to come. Someday, our next of kin would perceive it as nothing short of an honour to be bestowed with the responsibility of keeping the soul of Brand Alumil as pulsating as it is today, all the while tackling continuous market challenges.</p>
                            </div>
                            <div class="row padding">
                                <div class="col-md-4 no-gutters animate-box" data-animate-effect="fadeInLeft">
                                    <a href="#" class="steps active">
                                        <p class="icon"><span><i class="icon-check"></i></span></p>
                                        <h3>We are
                                            <br>
                                            pasionate</h3>
                                    </a>
                                </div>
                                <div class="col-md-4 no-gutters animate-box" data-animate-effect="fadeInLeft">
                                    <a href="#" class="steps">
                                        <p class="icon"><span><i class="icon-check"></i></span></p>
                                        <h3>Honest
                                            <br>
                                            Dependable</h3>
                                    </a>
                                </div>
                                <div class="col-md-4 no-gutters animate-box" data-animate-effect="fadeInLeft">
                                    <a href="#" class="steps">
                                        <p class="icon"><span><i class="icon-check"></i></span></p>
                                        <h3>Always
                                            <br>
                                            Improving</h3>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="colorlib-services">
                <div class="colorlib-narrow-content">
                    <div class="row">
                        <div class="col-md-6 col-md-offset-3 col-md-pull-3 animate-box" data-animate-effect="fadeInLeft">
                            <span class="heading-meta">What We do?</span>
                            <h2 class="colorlib-heading">Here are some of my expertise</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="colorlib-feature animate-box" data-animate-effect="fadeInLeft">
                                        <div class="colorlib-icon">
                                            <i class="flaticon-worker"></i>
                                        </div>
                                        <div class="colorlib-text">
                                            <h3>InDoor</h3>
                                            <p>To ensure top quality, we test our products along the entire production process through our multiple in-house Quality Control Laboratories.  </p>
                                        </div>
                                    </div>

                                    <div class="colorlib-feature animate-box" data-animate-effect="fadeInLeft">
                                        <div class="colorlib-icon">
                                            <i class="flaticon-sketch"></i>
                                        </div>
                                        <div class="colorlib-text">
                                            <h3>OutDoor</h3>
                                            <p>To ensure top quality, we test our products along the entire production process through our multiple in-house Quality Control Laboratories.  </p>
                                        </div>
                                    </div>

                                    <div class="colorlib-feature animate-box" data-animate-effect="fadeInLeft">
                                        <div class="colorlib-icon">
                                            <i class="flaticon-engineering"></i>
                                        </div>
                                        <div class="colorlib-text">
                                            <h3>Commercial</h3>
                                            <p>To ensure top quality, we test our products along the entire production process through our multiple in-house Quality Control Laboratories.  </p>
                                        </div>
                                    </div>

                                    <div class="colorlib-feature animate-box" data-animate-effect="fadeInLeft">
                                        <div class="colorlib-icon">
                                            <i class="flaticon-crane"></i>
                                        </div>
                                        <div class="colorlib-text">
                                            <h3>Fumagalli</h3>
                                            <p>To ensure top quality, we test our products along the entire production process through our multiple in-house Quality Control Laboratories.  </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6">
                                    <a href="services.html" class="services-wrap animate-box" data-animate-effect="fadeInRight">
                                        <div class="services-img" style="background-image: url(oimages/services-1.jpg)"></div>
                                        <div class="desc">
                                            <h3>Design &amp; Build</h3>
                                        </div>
                                    </a>
                                    <a href="services.html" class="services-wrap animate-box" data-animate-effect="fadeInRight">
                                        <div class="services-img" style="background-image: url(oimages/services-2.jpg)"></div>
                                        <div class="desc">
                                            <h3>InDoor</h3>
                                        </div>
                                    </a>
                                    <a href="services.html" class="services-wrap animate-box" data-animate-effect="fadeInRight">
                                        <div class="services-img" style="background-image: url(oimages/services-3.jpg)"></div>
                                        <div class="desc">
                                            <h3>OutDoor</h3>
                                        </div>
                                    </a>
                                </div>
                                <div class="col-md-6 move-bottom">
                                    <a href="services.html" class="services-wrap animate-box" data-animate-effect="fadeInRight">
                                        <div class="services-img" style="background-image: url(oimages/services-4.jpg)"></div>
                                        <div class="desc">
                                            <h3>Commercial</h3>
                                        </div>
                                    </a>
                                    <a href="services.html" class="services-wrap animate-box" data-animate-effect="fadeInRight">
                                        <div class="services-img" style="background-image: url(oimages/services-5.jpg)"></div>
                                        <div class="desc">
                                            <h3>Fumagalli</h3>
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

          

            <div class="colorlib-work">
                <div class="colorlib-narrow-content">
                    <div class="row">
                        <div class="col-md-6 col-md-offset-3 col-md-pull-3 animate-box" data-animate-effect="fadeInLeft">
                            <span class="heading-meta">Our Work</span>
                            <h2 class="colorlib-heading animate-box">Recent Work</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 animate-box" data-animate-effect="fadeInLeft">
                            <div class="project" style="background-image: url(oimg/22.jpg);">
                                <div class="desc">
                                    <div class="con">
                                        <h3><a href="work.html">Work 01</a></h3>
                                        <span>Building</span>
                                        <p class="icon">
                                            <span><a href="#"><i class="icon-share3"></i></a></span>
                                            <span><a href="#"><i class="icon-eye"></i>100</a></span>
                                            <span><a href="#"><i class="icon-heart"></i>49</a></span>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 animate-box" data-animate-effect="fadeInLeft">
                            <div class="project" style="background-image: url(oimg/22.jpg);">
                                <div class="desc">
                                    <div class="con">
                                        <h3><a href="work.html">Work 02</a></h3>
                                        <span>House, Apartment</span>
                                        <p class="icon">
                                            <span><a href="#"><i class="icon-share3"></i></a></span>
                                            <span><a href="#"><i class="icon-eye"></i>100</a></span>
                                            <span><a href="#"><i class="icon-heart"></i>49</a></span>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 animate-box" data-animate-effect="fadeInLeft">
                            <div class="project" style="background-image: url(oimg/22.jpg);">
                                <div class="desc">
                                    <div class="con">
                                        <h3><a href="work.html">Work 03</a></h3>
                                        <span>Dining Room</span>
                                        <p class="icon">
                                            <span><a href="#"><i class="icon-share3"></i></a></span>
                                            <span><a href="#"><i class="icon-eye"></i>100</a></span>
                                            <span><a href="#"><i class="icon-heart"></i>49</a></span>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 animate-box" data-animate-effect="fadeInLeft">
                            <div class="project" style="background-image: url(oimg/22.jpg);">
                                <div class="desc">
                                    <div class="con">
                                        <h3><a href="work.html">Work 04</a></h3>
                                        <span>House, Building</span>
                                        <p class="icon">
                                            <span><a href="#"><i class="icon-share3"></i></a></span>
                                            <span><a href="#"><i class="icon-eye"></i>100</a></span>
                                            <span><a href="#"><i class="icon-heart"></i>49</a></span>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 animate-box" data-animate-effect="fadeInLeft">
                            <div class="project" style="background-image: url(oimg/22.jpg);">
                                <div class="desc">
                                    <div class="con">
                                        <h3><a href="work.html">Work 05</a></h3>
                                        <span>Condo, Pad</span>
                                        <p class="icon">
                                            <span><a href="#"><i class="icon-share3"></i></a></span>
                                            <span><a href="#"><i class="icon-eye"></i>100</a></span>
                                            <span><a href="#"><i class="icon-heart"></i>49</a></span>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 animate-box" data-animate-effect="fadeInLeft">
                            <div class="project" style="background-image: url(oimg/22.jpg);">
                                <div class="desc">
                                    <div class="con">
                                        <h3><a href="work.html">Work 06</a></h3>
                                        <span>Table, Chairs</span>
                                        <p class="icon">
                                            <span><a href="#"><i class="icon-share3"></i></a></span>
                                            <span><a href="#"><i class="icon-eye"></i>100</a></span>
                                            <span><a href="#"><i class="icon-heart"></i>49</a></span>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!--<div class="colorlib-blog">
				<div class="colorlib-narrow-content">
					<div class="row">
						<div class="col-md-6 col-md-offset-3 col-md-pull-3 animate-box" data-animate-effect="fadeInLeft">
							<span class="heading-meta">Read</span>
							<h2 class="colorlib-heading">Recent Blog</h2>
						</div>
					</div>
					<div class="row">
						<div class="col-md-4 col-sm-6 animate-box" data-animate-effect="fadeInLeft">
							<div class="blog-entry">
								<a href="blog.html" class="blog-img"><img src="images/blog-1.jpg" class="img-responsive" alt="HTML5 Bootstrap Template by colorlib.com"></a>
								<div class="desc">
									<span><small>April 14, 2018 </small> | <small> Web Design </small> | <small> <i class="icon-bubble3"></i> 4</small></span>
									<h3><a href="blog.html">Renovating National Gallery</a></h3>
									<p>Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean.</p>
								</div>
							</div>
						</div>
						<div class="col-md-4 col-sm-6 animate-box" data-animate-effect="fadeInLeft">
							<div class="blog-entry">
								<a href="blog.html" class="blog-img"><img src="images/blog-2.jpg" class="img-responsive" alt="HTML5 Bootstrap Template by colorlib.com"></a>
								<div class="desc">
									<span><small>April 14, 2018 </small> | <small> Web Design </small> | <small> <i class="icon-bubble3"></i> 4</small></span>
									<h3><a href="blog.html">Wordpress for a Beginner</a></h3>
									<p>Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean.</p>
								</div>
							</div>
						</div>
						<div class="col-md-4 col-sm-6 animate-box" data-animate-effect="fadeInLeft">
							<div class="blog-entry">
								<a href="blog.html" class="blog-img"><img src="images/blog-3.jpg" class="img-responsive" alt="HTML5 Bootstrap Template by colorlib.com"></a>
								<div class="desc">
									<span><small>April 14, 2018 </small> | <small> Inspiration </small> | <small> <i class="icon-bubble3"></i> 4</small></span>
									<h3><a href="blog.html">Make website from scratch</a></h3>
									<p>Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean.</p>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>-->

            <div id="get-in-touch" class="colorlib-bg-color">
                <div class="colorlib-narrow-content">
                    <div class="row">
                        <div class="col-md-6 animate-box" data-animate-effect="fadeInLeft">
                            <h2>Get in Touch!</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-md-offset-3 col-md-pull-3 animate-box" data-animate-effect="fadeInLeft">
                            <p class="colorlib-lead">Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean.</p>
                            <p><a href="#" class="btn btn-primary btn-learn">Contact me!</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- jQuery -->
    <script src="ojs/jquery.min.js"></script>
    <!-- jQuery Easing -->
    <script src="ojs/jquery.easing.1.3.js"></script>
    <!-- Bootstrap -->
    <script src="ojs/bootstrap.min.js"></script>
    <!-- Waypoints -->
    <script src="ojs/jquery.waypoints.min.js"></script>
    <!-- Flexslider -->
    <script src="ojs/jquery.flexslider-min.js"></script>
    <!-- Sticky Kit -->
    <script src="ojs/sticky-kit.min.js"></script>
    <!-- Owl carousel -->
    <script src="ojs/owl.carousel.min.js"></script>
    <!-- Counters -->
    <script src="ojs/jquery.countTo.js"></script>

    <!-- MAIN JS -->
    <script src="ojs/main.js"></script>
</body>
</html>