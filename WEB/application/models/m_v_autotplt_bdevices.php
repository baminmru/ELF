
<?php
class  M_v_autotplt_bdevices extends CI_Model {
    public function  __construct()
    {
         parent::__construct();
    }
    function newRow($objtype,$name)  {
               $id = $this->jservice->get(array('Action'=>'NewGuid'));
               $this->jservice->get(array('Action'=>'NewDocument', 'TypeName'=>'TPLT', 'DocumentID'=>$id, 'DocumentCaption'=>$name));
               $rowid = $this->jservice->get(array('Action'=>'NewGuid'));
               $this->jservice->get(array('Action'=>'NewRow', 'PartName'=>'tplt_bdevices', 'RowID'=>$rowid, 'DocumentID'=>$id));
                if ($id) {
                    return array('success'=>TRUE, 'data' => $id, 'rowid'=>$rowid);
                }
                else {
                    $return= array('success'=>FALSE, 'msg' => 'Error while create new id');
				    return $return;
                }
    }
      function getRowsSL($offset,$limit, $sort = array(), $filter = null){
        $filter = (array)json_decode($filter);
       	$cond ='';
        $whereclause = '';
    try{
	    foreach($filter as $obj) {
		    $tmp = json_decode($obj->value);
		    if(is_array($tmp)) $obj->value = $tmp;	
		    switch($obj->property) {
			    //case 'value':
			    	//$cond = '';
			    	//break;
			  case 'tplt_bdevices_nplock_le':
			  $cond = 'tplt_bdevices_nplock<="'.$obj->value.'"';
			  break;
			  case 'tplt_bdevices_nplock_ge':
			  $cond = 'tplt_bdevices_nplock>="'.$obj->value.'"';
			  break;
		    	default:
			    	if(isset($obj->value))
			    	{
			    		if(is_array($obj->value))
				    	{
				    		$cond = $obj->property . ' IN ("' . implode('", "',$obj->value).'") ';
				    		//echo $cond;
					    }else
					    {
					    	$cond = $obj->property . ' LIKE "%' . $obj->value . '%"';
					    }
				    }else{
				        $cond='1=1';
				    }
		    }
		    $whereclause .= (empty($whereclause)) ? $cond : ' AND ' . $cond;
	    }
    }catch(Exception $e) {
	    log_message('error','Exception: '. $e->getMessage());
    }
	 if (isset($offset) && isset($limit)) {
	    $res = $this->jservice->get(array('Action' => 'GetViewData', 'ViewName' => 'v_autotplt_bdevices','FieldList'=>'instanceid,id,tplt_bdevices_theschema,DATE_FORMAT(tplt_bdevices_nplock,\'%Y-%m-%d %H:%i:%s\') tplt_bdevices_nplock,tplt_bdevices_shab,tplt_bdevices_theserver,tplt_bdevices_thenode,tplt_bdevices_devtype,tplt_bdevices_name,tplt_bdevices_devgrp,tplt_bdevices_addr,tplt_bdevices_thephone,tplt_bdevices_connected','Sort'=>$sort, 'WhereClause' => $whereclause,'Limit'=>$limit,'Offset'=>$offset));
	} else {
	    $res = $this->jservice->get(array('Action' => 'GetViewData', 'ViewName' => 'v_autotplt_bdevices','FieldList'=>'instanceid,id,tplt_bdevices_theschema,DATE_FORMAT(tplt_bdevices_nplock,\'%Y-%m-%d %H:%i:%s\') tplt_bdevices_nplock,tplt_bdevices_shab,tplt_bdevices_theserver,tplt_bdevices_thenode,tplt_bdevices_devtype,tplt_bdevices_name,tplt_bdevices_devgrp,tplt_bdevices_addr,tplt_bdevices_thephone,tplt_bdevices_connected','Sort'=>$sort, 'WhereClause' => $whereclause));
	}
	$root = new stdClass();
	$root->total = $this->jservice->get(array('Action' => 'CountView', 'ViewName' => 'v_autotplt_bdevices','FieldList'=>'instanceid,id,tplt_bdevices_theschema,DATE_FORMAT(tplt_bdevices_nplock,\'%Y-%m-%d %H:%i:%s\') tplt_bdevices_nplock,tplt_bdevices_shab,tplt_bdevices_theserver,tplt_bdevices_thenode,tplt_bdevices_devtype,tplt_bdevices_name,tplt_bdevices_devgrp,tplt_bdevices_addr,tplt_bdevices_thephone,tplt_bdevices_connected', 'WhereClause' => $whereclause));
	$root->success = true;
	$root->rows = $res;
	return $root;
}
    function deleteRow($id = null) {
	    $this->jservice->get(array('Action'=>'DeleteDocument', 'TypeName'=>'tplt', 'DocumentID'=>$id));
	    $return = array('success' => true);
	    return $return;
    }
}
?>