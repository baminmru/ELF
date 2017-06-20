
<?php
class  M_tplt_valuebounds extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tplt_valueboundsid) as tplt_valueboundsid, B2G(tplt_valueboundsid) as id,B2G(instanceid) as instanceid, TPLT_VALUEBOUNDS_BRIEF_F(tplt_valueboundsid , NULL) as  brief,pmax,pmin,ismin, case ismin  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as ismin_grid,B2G(PTYPE) ptype, TPLD_PARAMTYPE_BRIEF_F(ptype, NULL) as ptype_grid,B2G(PNAME) pname, TPLD_PARAM_BRIEF_F(pname, NULL) as pname_grid,ismax, case ismax  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as ismax_grid', 'PartName' => 'tplt_valuebounds', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tplt_valueboundsid'])) {
	        $data['tplt_valueboundsid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplt_valuebounds', 'RowID' => $data['tplt_valueboundsid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tplt_valuebounds', 'RowID' => $data['tplt_valueboundsid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tplt_valueboundsid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplt_valuebounds', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_valueboundsid) as tplt_valueboundsid, B2G(tplt_valueboundsid) as id,B2G(instanceid) as instanceid, TPLT_VALUEBOUNDS_BRIEF_F(tplt_valueboundsid , NULL) as  brief,pmax,pmin,ismin, case ismin  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as ismin_grid,B2G(PTYPE) ptype, TPLD_PARAMTYPE_BRIEF_F(ptype, NULL) as ptype_grid,B2G(PNAME) pname, TPLD_PARAM_BRIEF_F(pname, NULL) as pname_grid,ismax, case ismax  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as ismax_grid', 'ViewName' => 'tplt_valuebounds'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_valueboundsid) as tplt_valueboundsid, B2G(tplt_valueboundsid) as id,B2G(instanceid) as instanceid, TPLT_VALUEBOUNDS_BRIEF_F(tplt_valueboundsid , NULL) as  brief,pmax,pmin,ismin, case ismin  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as ismin_grid,B2G(PTYPE) ptype, TPLD_PARAMTYPE_BRIEF_F(ptype, NULL) as ptype_grid,B2G(PNAME) pname, TPLD_PARAM_BRIEF_F(pname, NULL) as pname_grid,ismax, case ismax  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as ismax_grid', 'ViewName' => 'tplt_valuebounds', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_valueboundsid) as tplt_valueboundsid, B2G(tplt_valueboundsid) as id,B2G(instanceid) as instanceid, TPLT_VALUEBOUNDS_BRIEF_F(tplt_valueboundsid , NULL) as  brief,pmax,pmin,ismin, case ismin  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as ismin_grid,B2G(PTYPE) ptype, TPLD_PARAMTYPE_BRIEF_F(ptype, NULL) as ptype_grid,B2G(PNAME) pname, TPLD_PARAM_BRIEF_F(pname, NULL) as pname_grid,ismax, case ismax  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as ismax_grid', 'ViewName' => 'tplt_valuebounds', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tplt_valuebounds', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>