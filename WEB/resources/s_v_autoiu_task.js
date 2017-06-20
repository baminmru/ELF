
 Ext.define('model_v_autoiu_task',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'instanceid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name:'iu_task_taskcancelled', type: 'string'}
            ,{name:'iu_task_processstatus', type: 'string'}
            ,{name:'iu_task_subj', type: 'string'}
            ,{name:'iu_task_doer_comment', type: 'string'}
            ,{name:'iu_task_controller_comment', type: 'string'}
            ,{name:'iu_task_taskfinished', type: 'string'}
            ,{name:'iu_task_createdate', type: 'string'}
            ,{name:'iu_task_delegatefrom', type: 'string'}
            ,{name:'iu_task_statetask', type: 'string'}
            ,{name:'iu_task_ischecked', type: 'string'}
            ,{name:'iu_task_contoller', type: 'string'}
            ,{name:'iu_task_doer', type: 'string'}
            ,{name:'iu_task_doer_states', type: 'string'}
            ,{name:'iu_task_finishdate', type: 'string'}
            ,{name:'iu_task_senttodoer', type: 'string'}
            ,{name:'iu_task_info', type: 'string'}
            ,{name:'iu_task_planenddate', type: 'string'}
        ]
    });

    var store_v_autoiu_task = Ext.create('Ext.data.Store', {
        model:'model_v_autoiu_task',
        autoLoad: false,
        autoSync: false,
        remoteSort: true,
        remoteFilter:true,
        pageSize : 30,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_v_autoiu_task/getRows',
            reader: {
                type:   'json'
                ,root:  'rows'
                ,totalProperty: 'total'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            },
            listeners: {
                exception: function(proxy, response, operation){
                    Ext.MessageBox.show({
                        title: 'REMOTE EXCEPTION',
                        msg:    operation.getError(),
                        icon : Ext.MessageBox.ERROR,
                        buttons : Ext.Msg.OK
                    });
                }
            }
        }
    });