<?php	
	header("Cache-Control: no-store, no-cache, must-revalidate");
	session_start();
	log_message('debug', 'appview: B2SESSION >'.$_SESSION['B2SESSION'].'<' );
				 
	if (!isset($_SESSION['B2SESSION']) || $_SESSION['B2SESSION']=='') 
	{
?>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>Учет Энергии</title>
	<link href="resources/images/logo3.png" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="resources/css/ext-all.css"/>
	<link rel="stylesheet" type="text/css" href="resources/css/CheckHeader.css" />
	<link rel="stylesheet" type="text/css" href="resources/css/ext-overrides.css"/>
	<script>
		var rootURL= "/elf/";
		var stateFulSystem=false;
	</script>
	
	
 
    <link rel="stylesheet" type="text/css" href="resources/css/icons.css"/>
    <!-- <link rel="stylesheet" type="text/css" href="resources/css/ext-overrides.css"/> -->

    <script type="text/javascript" src="ext-all-debug.js"></script>
	<!-- <script type="text/javascript" src="ext-neptune-debug.js"></script> -->
	<!-- <script type="text/javascript" src="bootstrap.js"></script> -->
	<script type="text/javascript" src="ux/InputTextMask.js"></script>
	<script type="text/javascript" src="ux/CheckColumn.js"></script>
	<script type="text/javascript" src="ux/grid/FiltersFeature.js"></script>
	<script type="text/javascript" src="ux/statusbar/StatusBar.js"></script>
    
	 <script type="text/javascript" src="resources/exporter/Base64.js"></script>
	 <script type="text/javascript" src="resources/exporter/Cell.js"></script>
	 <script type="text/javascript" src="resources/exporter/Style.js"></script>
	 <script type="text/javascript" src="resources/exporter/Worksheet.js"></script>
	 <script type="text/javascript" src="resources/exporter/Workbook.js"></script>
	 
	 
	 <script type="text/javascript" src="locale/ext-lang-ru.js"></script>
	 <script type="text/javascript" src="resources/myfileuploader.js"></script>
	 <script type="text/javascript" src="resources/common.js"></script>
	 <script type="text/javascript" src="resources/reporter.js"></script>
	 <script type="text/javascript" src="resources/reporterd.js"></script>
	<script type="text/javascript" src="resources/app.js"></script>
	 
	
   
    <script type="text/javascript">
        var combo_pbar = null;
        var combo_timeout_id = null;
        var combo_StoreLoading = false;
        var combo_Waiter = 0;
        var combo_Index = -1;
        var combo_Stores = new Array();
    </script>
    <!-- Model and stores JavaScript -->
    <script type="text/javascript" src="resources/models.js"></script>
    <script type="text/javascript" src="resources/enums.js"></script>

   <?php require('inc.php'); ?>

    <!-- Application JavaScript -->
	

	<script type="text/javascript" src="resources/login.js"></script>
	<script type="text/javascript" src="resources/menu.js"></script>

	
</head>
<body>
<div id="loading-mask"></div>
<div id="loading"><span id="loading-message"></span></div>
</body>
</html>


<?php
		//exit();
	}	else{
?>
<html>
<head>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>Учет Энергии</title>
	<link href="resources/images/logo3.png" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="resources/css/ext-all.css"/>
	 <link rel="stylesheet" type="text/css" href="resources/css/ext-overrides.css"/>
	<link rel="stylesheet" type="text/css" href="resources/css/CheckHeader.css" />
	<script>
			var rootURL= "/elf/";
		var stateFulSystem=false;
	</script>
	
	
 
    <link rel="stylesheet" type="text/css" href="resources/css/icons.css"/>
    <!-- <link rel="stylesheet" type="text/css" href="resources/css/ext-overrides.css"/> -->

    <script type="text/javascript" src="ext-all-debug.js"></script>
	<!-- <script type="text/javascript" src="ext-neptune-debug.js"></script> -->
	<!-- <script type="text/javascript" src="bootstrap.js"></script> -->
	<script type="text/javascript" src="ux/InputTextMask.js"></script>
	<script type="text/javascript" src="ux/CheckColumn.js"></script>
	<script type="text/javascript" src="ux/grid/FiltersFeature.js"></script>
	<script type="text/javascript" src="ux/statusbar/StatusBar.js"></script>
    
	 <script type="text/javascript" src="resources/exporter/Base64.js"></script>
	 <script type="text/javascript" src="resources/exporter/Cell.js"></script>
	 <script type="text/javascript" src="resources/exporter/Style.js"></script>
	 <script type="text/javascript" src="resources/exporter/Worksheet.js"></script>
	 <script type="text/javascript" src="resources/exporter/Workbook.js"></script>
	 
	 
	 <script type="text/javascript" src="locale/ext-lang-ru.js"></script>
     <script type="text/javascript" src="resources/myfileuploader.js"></script>
	  <script type="text/javascript" src="resources/common.js"></script>
	   <script type="text/javascript" src="resources/reporter.js"></script>
	   <script type="text/javascript" src="resources/reporterd.js"></script>
	<script type="text/javascript" src="resources/app.js"></script>

   
    <script type="text/javascript">
        var combo_pbar = null;
        var combo_timeout_id = null;
        var combo_StoreLoading = false;
        var combo_Waiter = 0;
        var combo_Index = -1;
        var combo_Stores = new Array();
    </script>
    <!-- Model and stores JavaScript -->
    <script type="text/javascript" src="resources/models.js"></script>
    <script type="text/javascript" src="resources/enums.js"></script>

   <?php require('inc.php'); ?>

    <!-- Application JavaScript -->

	<script type="text/javascript" src="resources/logged.js"></script>
	<script type="text/javascript" src="resources/menu.js"></script>

	
</head>
<body>
<div id="loading-mask"></div>
<div id="loading"><span id="loading-message"></span></div>
</body>
</html>
<?php
		
	}	
?>