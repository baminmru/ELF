
<?php
class  M_tpld_param extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tpld_paramid) as tpld_paramid, B2G(tpld_paramid) as id,B2G(instanceid) as instanceid, TPLD_PARAM_BRIEF_F(tpld_paramid , NULL) as  brief,name,paramfield,showas, case showas  when 0 then \'As String\' when 1 then \'As Numeric\' when 2 then \'As Date\' else \'\'  end   as showas_grid', 'PartName' => 'tpld_param', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tpld_paramid'])) {
	        $data['tpld_paramid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpld_param', 'RowID' => $data['tpld_paramid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tpld_param', 'RowID' => $data['tpld_paramid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tpld_paramid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpld_param', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpld_paramid) as tpld_paramid, B2G(tpld_paramid) as id,B2G(instanceid) as instanceid, TPLD_PARAM_BRIEF_F(tpld_paramid , NULL) as  brief,name,paramfield,showas, case showas  when 0 then \'As String\' when 1 then \'As Numeric\' when 2 then \'As Date\' else \'\'  end   as showas_grid', 'ViewName' => 'tpld_param'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpld_paramid) as tpld_paramid, B2G(tpld_paramid) as id,B2G(instanceid) as instanceid, TPLD_PARAM_BRIEF_F(tpld_paramid , NULL) as  brief,name,paramfield,showas, case showas  when 0 then \'As String\' when 1 then \'As Numeric\' when 2 then \'As Date\' else \'\'  end   as showas_grid', 'ViewName' => 'tpld_param', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpld_paramid) as tpld_paramid, B2G(tpld_paramid) as id,B2G(instanceid) as instanceid, TPLD_PARAM_BRIEF_F(tpld_paramid , NULL) as  brief,name,paramfield,showas, case showas  when 0 then \'As String\' when 1 then \'As Numeric\' when 2 then \'As Date\' else \'\'  end   as showas_grid', 'ViewName' => 'tpld_param', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tpld_param', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>