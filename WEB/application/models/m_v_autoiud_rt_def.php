﻿
<?php
class  M_v_autoiud_rt_def extends CI_Model {
    public function  __construct()
    {
         parent::__construct();
    }
    function newRow($objtype,$name)  {
               $id = $this->jservice->get(array('Action'=>'NewGuid'));
               $this->jservice->get(array('Action'=>'NewDocument', 'TypeName'=>'iud_rt', 'DocumentID'=>$id, 'DocumentCaption'=>$name));
               $rowid = $this->jservice->get(array('Action'=>'NewGuid'));
               $this->jservice->get(array('Action'=>'NewRow', 'PartName'=>'iud_rt_def', 'RowID'=>$rowid, 'DocumentID'=>$id));
                if ($id) {
                    return array('success'=>TRUE, 'data' => $id, 'rowid'=>$rowid);
                }
                else {
                    $return= array('success'=>FALSE, 'msg' => 'Error while create new id');
				    return $return;
                }
    }
      function getRowsSL($offset,$limit, $sort = array(), $filter = null)
{
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
	    $res = $this->jservice->get(array('Action' => 'GetViewData', 'ViewName' => 'v_autoiud_rt_def','FieldList'=>'instanceid,id,iud_rt_def_name','Sort'=>$sort, 'WhereClause' => $whereclause,'Limit'=>$limit,'Offset'=>$offset));
	} else {
	    $res = $this->jservice->get(array('Action' => 'GetViewData', 'ViewName' => 'v_autoiud_rt_def','FieldList'=>'instanceid,id,iud_rt_def_name','Sort'=>$sort, 'WhereClause' => $whereclause));
	}
	$root = new stdClass();
	$root->total = $this->jservice->get(array('Action' => 'CountView', 'ViewName' => 'v_autoiud_rt_def','FieldList'=>'instanceid,id,iud_rt_def_name', 'WhereClause' => $whereclause));
	$root->success = true;
	$root->rows = $res;
	return $root;
}
    function deleteRow($id = null) {
	    $this->jservice->get(array('Action'=>'DeleteDocument', 'TypeName'=>'iud_rt', 'DocumentID'=>$id));
	    $return = array('success' => true);
	    return $return;
    }
}
?>