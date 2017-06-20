
Ext.require([
'Ext.form.*'
]);
  tpls_= null;
function TPLS_Panel_(objectID, RootPanel, selection){ 


    var store_tpls_info = Ext.create('Ext.data.Store', {
        model:'model_tpls_info',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpls_info/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tpls_param = Ext.create('Ext.data.Store', {
        model:'model_tpls_param',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpls_param/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });
          DefineForms_tpls_info_();
          DefineForms_tpls_param_();
     var   int_tpls_info_     =      DefineInterface_tpls_info_('int_tpls_info',store_tpls_info, selection);
     var   int_tpls_param_     =      DefineInterface_tpls_param_('int_tpls_param',store_tpls_param);
     tpls_= Ext.create('Ext.form.Panel', {
      id: 'tpls',
      layout:'fit',
      fieldDefaults: {
          labelAlign:             'top',
          msgTarget:              'side'
        },
        defaults: {
        anchor:'100%'
        },

        instanceid:objectID,
                onCommit: function(){
        		},
        		onButtonOk: function()
        		{
        			var me = this;
        	    int_tpls_info_.doSave( me.onCommit);
        		},
        		onButtonCancel: function()
        		{
        		},
        canClose: function(){
        	return int_tpls_info_.canClose();
        },
        items: [{
            xtype:'tabpanel',
            itemId:'tabs_tpls',
            activeTab: 0,
            layout: 'fit',
            tabPosition:'top',
            border:0,
            items:[   // tabs
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Схема подключения',
            layout:'fit',
            itemId:'tab_tpls_info',
            items:[ // panel on tab 
int_tpls_info_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Параметры на схеме',
            layout:'fit',
            itemId:'tab_tpls_param',
            items:[ // panel on tab 
int_tpls_param_
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       tpls_.closable= true;
       tpls_.title= 'Схема подключения';
       tpls_.frame= true;
    }else{
       tpls_.closable= false;
       tpls_.title= '';
       tpls_.frame= false;
    }
   store_tpls_info.on('load', function() {
        if(store_tpls_info.count()==0){
            store_tpls_info.insert(0, new model_tpls_info());
        }
        record= store_tpls_info.getAt(0);
        record['instanceid']=objectID;
   int_tpls_info_.setActiveRecord(record,objectID);	
   });
       store_tpls_info.load( {params:{ instanceid:objectID} }  );
   int_tpls_param_.instanceid=objectID;	
       store_tpls_param.load(  {params:{ instanceid:objectID} } );
    return tpls_;
}