
 Ext.define('model_v_autotpq_def',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'instanceid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name:'tpq_def_thedevice', type: 'string'}
            ,{name:'tpq_def_isurgent', type: 'string'}
            ,{name:'tpq_def_repeattimes', type: 'number'}
            ,{name:'tpq_def_archtype', type: 'string'}
            ,{name:'tpq_def_repeatinterval', type: 'number'}
            ,{name:'tpq_def_querytime', type: 'string'}
            ,{name:'tpq_def_thesessionid', type: 'string'}
            ,{name:'tpq_def_archtime', type: 'string'}
        ]
    });

    var store_v_autotpq_def = Ext.create('Ext.data.Store', {
        model:'model_v_autotpq_def',
        autoLoad: false,
        autoSync: false,
        remoteSort: true,
        remoteFilter:true,
        pageSize : 30,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_v_autotpq_def/getRows',
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