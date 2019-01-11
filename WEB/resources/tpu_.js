
Ext.require([
'Ext.form.*'
]);
  tpu_= null;
function TPU_Panel_(objectID, RootPanel, selection){ 


    var store_tpu_def = Ext.create('Ext.data.Store', {
        model:'model_tpu_def',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpu_def/getRows',
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

    var store_tpu_device = Ext.create('Ext.data.Store', {
        model:'model_tpu_device',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpu_device/getRows',
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

    var store_tpu_views = Ext.create('Ext.data.Store', {
        model:'model_tpu_views',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpu_views/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        }
    });

    var store_tpu_reports = Ext.create('Ext.data.Store', {
        model:'model_tpu_reports',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpu_reports/getRows',
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
          DefineForms_tpu_def_();
          DefineForms_tpu_device_();
          DefineForms_tpu_reports_();
     var   int_tpu_def_     =      DefineInterface_tpu_def_('int_tpu_def',store_tpu_def, selection);
     var   int_tpu_device_     =      DefineInterface_tpu_device_('int_tpu_device',store_tpu_device);
     var   int_tpu_reports_     =      DefineInterface_tpu_reports_('int_tpu_reports',store_tpu_reports);
     tpu_= Ext.create('Ext.form.Panel', {
      id: 'tpu',
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
        	    int_tpu_def_.doSave( me.onCommit);
        		},
        		onButtonCancel: function()
        		{
        		},
        canClose: function(){
        	return int_tpu_def_.canClose();
        },
        items: [{
            xtype:'tabpanel',
            itemId:'tabs_tpu',
            activeTab: 0,
            layout: 'fit',
            tabPosition:'top',
            border:0,
            items:[   // tabs
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Принадлежность',
            layout:'fit',
            itemId:'tab_tpu_def',
            items:[ // panel on tab 
int_tpu_def_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Настройки узла',
            layout:'fit',
            itemId:'tab_tpu_device',
            items:[ // panel on tab 
int_tpu_device_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Отчеты',
            layout:'fit',
            itemId:'tab_tpu_reports',
            items:[ // panel on tab 
int_tpu_reports_
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       tpu_.closable= true;
       tpu_.title= 'Персонификация';
       tpu_.frame= true;
    }else{
       tpu_.closable= false;
       tpu_.title= '';
       tpu_.frame= false;
    }
   store_tpu_def.on('load', function() {
        if(store_tpu_def.count()==0){
            store_tpu_def.insert(0, new model_tpu_def());
        }
        record= store_tpu_def.getAt(0);
        record['instanceid']=objectID;
   int_tpu_def_.setActiveRecord(record,objectID);	
   });
       store_tpu_def.load( {params:{ instanceid:objectID} }  );
   int_tpu_device_.instanceid=objectID;	
       store_tpu_device.load(  {params:{ instanceid:objectID} } );
   int_tpu_reports_.instanceid=objectID;	
       store_tpu_reports.load(  {params:{ instanceid:objectID} } );
    return tpu_;
}