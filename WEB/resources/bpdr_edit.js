﻿
Ext.require([
'Ext.form.*'
]);
  bpdr_edit= null;
function bpdr_Panel_edit(objectID, RootPanel, selection){ 


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
          DefineForms_iu_crole_edit();
     var   int_iu_crole_edit     =      DefineInterface_iu_crole_edit('int_iu_crole',store_iu_crole);
     bpdr_edit= Ext.create('Ext.form.Panel', {
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
int_iu_crole_edit
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       bpdr_edit.closable= true;
       bpdr_edit.title= 'Роль сотрудника';
       bpdr_edit.frame= true;
    }else{
       bpdr_edit.closable= false;
       bpdr_edit.title= '';
       bpdr_edit.frame= false;
    }
   int_iu_crole_edit.instanceid=objectID;	
       store_iu_crole.load(  {params:{ instanceid:objectID} } );
    return bpdr_edit;
}