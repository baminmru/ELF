﻿
Ext.require([
'Ext.form.*'
]);
  iud_rt_read= null;
function iud_rt_Panel_read(objectID, RootPanel, selection){ 


    var store_iud_rt_def = Ext.create('Ext.data.Store', {
        model:'model_iud_rt_def',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_iud_rt_def/getRows',
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
          DefineForms_iud_rt_def_read();
     var   int_iud_rt_def_read     =      DefineInterface_iud_rt_def_read('int_iud_rt_def',store_iud_rt_def);
     iud_rt_read= Ext.create('Ext.form.Panel', {
      id: 'iud_rt',
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
            itemId:'tabs_iud_rt',
            activeTab: 0,
            layout: 'fit',
            tabPosition:'top',
            border:0,
            items:[   // tabs
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Тип ссылки',
            layout:'fit',
            itemId:'tab_iud_rt_def',
            items:[ // panel on tab 
int_iud_rt_def_read
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       iud_rt_read.closable= true;
       iud_rt_read.title= 'Тип ссылки';
       iud_rt_read.frame= true;
    }else{
       iud_rt_read.closable= false;
       iud_rt_read.title= '';
       iud_rt_read.frame= false;
    }
   int_iud_rt_def_read.instanceid=objectID;	
       store_iud_rt_def.load(  {params:{ instanceid:objectID} } );
    return iud_rt_read;
}