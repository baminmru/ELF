
Ext.require([
'Ext.form.*'
]);
  bpdi_read= null;
function bpdi_Panel_read(objectID, RootPanel, selection){ 


    var store_iu_int_modules = Ext.create('Ext.data.Store', {
        model:'model_iu_int_modules',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_iu_int_modules/getRows',
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
          DefineForms_iu_int_modules_read();
     var   int_iu_int_modules_read     =      DefineInterface_iu_int_modules_read('int_iu_int_modules',store_iu_int_modules);
     bpdi_read= Ext.create('Ext.form.Panel', {
      id: 'bpdi',
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
        		},
        		onButtonCancel: function()
        		{
        		},
        canClose: function(){
        	return true;
        },
        items: [{
            xtype:'tabpanel',
            itemId:'tabs_bpdi',
            activeTab: 0,
            layout: 'fit',
            tabPosition:'top',
            border:0,
            items:[   // tabs
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Модуль',
            layout:'fit',
            itemId:'tab_iu_int_modules',
            items:[ // panel on tab 
int_iu_int_modules_read
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       bpdi_read.closable= true;
       bpdi_read.title= 'Интерфейс';
       bpdi_read.frame= true;
    }else{
       bpdi_read.closable= false;
       bpdi_read.title= '';
       bpdi_read.frame= false;
    }
   int_iu_int_modules_read.instanceid=objectID;	
       store_iu_int_modules.load(  {params:{ instanceid:objectID} } );
    return bpdi_read;
}