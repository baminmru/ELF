
Ext.require([
'Ext.form.*'
]);
  bpdr_read= null;
function bpdr_Panel_read(objectID, RootPanel, selection){ 


    var store_iu_crole = Ext.create('Ext.data.Store', {
        model:'model_iu_crole',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_iu_crole/getRows',
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
          DefineForms_iu_crole_read();
     var   int_iu_crole_read     =      DefineInterface_iu_crole_read('int_iu_crole',store_iu_crole);
     bpdr_read= Ext.create('Ext.form.Panel', {
      id: 'bpdr',
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
            itemId:'tabs_bpdr',
            activeTab: 0,
            layout: 'fit',
            tabPosition:'top',
            border:0,
            items:[   // tabs
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Роль',
            layout:'fit',
            itemId:'tab_iu_crole',
            items:[ // panel on tab 
int_iu_crole_read
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       bpdr_read.closable= true;
       bpdr_read.title= 'Роль сотрудника';
       bpdr_read.frame= true;
    }else{
       bpdr_read.closable= false;
       bpdr_read.title= '';
       bpdr_read.frame= false;
    }
   int_iu_crole_read.instanceid=objectID;	
       store_iu_crole.load(  {params:{ instanceid:objectID} } );
    return bpdr_read;
}