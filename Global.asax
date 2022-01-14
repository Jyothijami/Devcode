<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //System.Web.Optimization.BundleTable.Bundles.Add(new System.Web.Optimization.ScriptBundle("~/bundle/js")
        //      .Include("~/js/*.js", "~/js/jquery-{version}.js", "~/js/plugins/forms/*.js", "~/js/plugins/interface/*.js"));

        //System.Web.Optimization.BundleTable.Bundles.Add(new System.Web.Optimization.ScriptBundle("~/bundle/css")
        //     .Include("~/css/*.css", "~/css/*.min.css"));  

        //System.Web.Optimization.BundleTable.EnableOptimizations = true;

        //System.Web.Optimization.BundleTable.Bundles.Add(new System.Web.Optimization.ScriptBundle("~/Optimized/Js").IncludeDirectory("~/js", "*.js"));
        //System.Web.Optimization.BundleTable.Bundles.Add(new System.Web.Optimization.ScriptBundle("~/Optimized/Js1").IncludeDirectory("~/js", "*.min.js"));
        //System.Web.Optimization.BundleTable.Bundles.Add(new System.Web.Optimization.StyleBundle("~/Optimized/CSS").IncludeDirectory("~/css", "*.css"));
        //System.Web.Optimization.BundleTable.Bundles.Add(new System.Web.Optimization.StyleBundle("~/Optimized/CSS1").IncludeDirectory("~/css", "*.min.css")); 
       
        
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
