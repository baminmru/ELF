

Ext.require([
'Ext.form.*'
]);

 var enum_ReportH= Ext.create('Ext.data.ArrayStore', {
  fields: [ {name: 'name'}, {name: 'value', type: 'string'} ], 
  data: [ 
	['2 канала','Hx2.mrt'],
	['3 канала','Hx3.mrt'],
	['4 канала','Hx4.mrt'],
	['5 каналов','Hx5.mrt'],
	['5 каналов Т','HTx5.mrt']
 ]});

function ReportsH( ){ 

  var rpanel= Ext.create('Ext.form.Panel', {
       closable: true,
       id:     'iu_report',
       title: 'Часовые отчеты',
      layout: 'fit',
      flex: 1,
      fieldDefaults: {
         labelAlign:             'top',
          msgTarget:             'side'
        },
        defaults: {
        anchor:'100%'
        },

        items: [
		{
		  xtype:'panel',	
          frame: false,
		  closable:true,
		  layout: 'fit',
		  flex: 1,
		 title: 'Часовые',
		 reportfile:'',
		 html:'<iframe id="rep_h_frame_id" width="100%"  height="100%" src=""></iframe>',
		 rbar:
                [
                {
                    xtype:  'form',
                    title:  'Параметры отчета',
                    iconCls:  'icon-script_gear',
                    flex:1,
					collapsible:true,
                    collapseDirection:  'right',
					animCollapse: false, 
					titleCollapse:true,
					bodyPadding:5,
					width:250,
					minWidth:250,
					autoScroll:true,
                    buttonAlign:  'center',
					layout: {
                    type:   'vbox',
                    align:  'stretch'
				},
                defaultType:  'textfield',
				items: [
				
						{

						trigger1Cls:        'x-form-clear-trigger', 
						trigger2Cls:        'x-form-select-trigger', 
						hideTrigger1:false, 
						hideTrigger2:false, 
						onTrigger1Click : function(){
								this.collapse();
								this.clearValue();
						},
						onTrigger2Click : function(){ 
								if(this.isExpanded) {
									this.collapse(); 
								}else{ 
									this.expand();
								}
						},
						editable: true,
						enableRegEx: true,
						queryMode:'local',
						listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Отчет'});} },
						xtype:  'combobox',
						store: enum_ReportH,
						valueField:     'value',
						displayField:   'name',
						typeAhead: true,
						name:   'reportname',
						itemId:   'reportname',
						fieldLabel:  'Вариант отчета',
						emptyText:      'Выбрать отчет',
						hideLabel:  false
						}	,
					
						{

						trigger1Cls:        'x-form-clear-trigger', 
						trigger2Cls:        'x-form-select-trigger', 
						hideTrigger1:false, 
						hideTrigger2:false, 
						onTrigger1Click : function(){
								this.collapse();
								this.clearValue();
						},
						onTrigger2Click : function(){ 
								if(this.isExpanded) {
									this.collapse(); 
								}else{ 
									this.store.load();
									this.expand();
								}
						},
						editable: true,
						enableRegEx: true,
						queryMode:'local',
						listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Узел'});} },
						xtype:  'combobox',
						store: cmbstore_tplt_bdevices,
						valueField:     'id',
						displayField:   'brief',
						typeAhead: true,
						name:   'device',
						itemId:   'device',
						fieldLabel:  'Узел',
						emptyText:      'Выбрать Узел ',
						hideLabel:  false
						}	,
				
						{

						xtype:  'datefield',
						format:'d/m/Y',
						submitFormat:'Y-m-d H:i:s',
						value:  '',
						name:  'dfrom',
						itemId: 'dfrom',
						fieldLabel: 'Дата C',
						emptyText:'не задано',
						submitEmptyText: false,
						listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Дата C'});}}
						}
						,
						{

						xtype:  'datefield',
						format:'d/m/Y',
						submitFormat:'Y-m-d H:i:s',
						value:  '',
						name:  'dto',
						itemId: 'dto',
						fieldLabel: 'Дата по',
						emptyText:'не задано',
						submitEmptyText: false,
						listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Дата по'});}}
						}
						
					],
				buttons: 
                    [
                        {
                            text: 'Пуск',
							iconCls:'icon-script_start',
                            formBind: true, 
                            disabled: false,
                            grid: this,
                            handler: function() {
                                var user_input =this.up('form').getForm().getValues(false,true);
								
								
								var src=rootURL+'/reports/stimulsoft/index.php?stimulsoft_client_key=ViewerFx&stimulsoft_report_key=';
								if(user_input['reportname'] && user_input['device']){
									src=src+user_input['reportname'];
									src=src+"&id="+user_input['device'];
								
									if(user_input['dfrom']==null && user_input['dto']==null){
										
										src=src+'&dfrom='+'2000-01-01';
										var cd=new Date();  
										cd.setDate(cd.getDate()+1);
										src=src+'&dto='+cd.toLocaleFormat('%Y-%m-%d');
										src=src+'&hdr=' + 'За весь период';
									}
								
									if(user_input['dfrom']==null && user_input['dto']!=null ){
										src=src+'&dfrom='+'2000-01-01';
										src=src+'&dto='+user_input['dto'];	
										src=src+'&hdr=' + ' По ' +myDateOnlyRenderer(user_input['dto']);
									}
									
									if(user_input['dfrom']!=null && user_input['dto']==null ){
										
										src=src+'&dfrom='+user_input['dfrom'];
										var cd=new Date();  
										cd.setDate(cd.getDate()+1);
										src=src+'&dto='+cd.toLocaleFormat('%Y-%m-%d');
										src=src+'&hdr=' + ' C ' +myDateOnlyRenderer(user_input['dfrom']);
									}
									if(user_input['dfrom']!=null && user_input['dto']!=null ){
										src=src+'&dfrom='+user_input['dfrom'];
										src=src+'&dto='+user_input['dto'];	
										src=src+'&hdr=' +' C ' +myDateOnlyRenderer(user_input['dfrom'])+ ' По ' +myDateOnlyRenderer(user_input['dto']);
									}
									
									
									//alert(src);
									Ext.getElementById('rep_h_frame_id').src =encodeURI(src);
								}
                             
                            }
                        }  
						/*, 
						{
							text: 'Сбросить',
							iconCls:'icon-cancel',
                            grid: this,
                            handler: function() {
                                //console.log(this.up('form'));
                                this.up('form').getForm().reset();
                                
                            }
						
                        }*/
                    ]
                }
            ]//rbar
    }] // tabpanel
    }); //Ext.Create
    return rpanel;
}
