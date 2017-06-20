
<?php
class  M_tplt_mask extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tplt_maskid) as tplt_maskid, B2G(tplt_maskid) as id,B2G(instanceid) as instanceid, TPLT_MASK_BRIEF_F(tplt_maskid , NULL) as  brief,B2G(PNAME) pname, TPLD_PARAM_BRIEF_F(pname, NULL) as pname_grid,phide, case phide  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as phide_grid,colwidth,sequence,B2G(PTYPE) ptype, TPLD_PARAMTYPE_BRIEF_F(ptype, NULL) as ptype_grid,paramformat', 'PartName' => 'tplt_mask', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tplt_maskid'])) {
	        $data['tplt_maskid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplt_mask', 'RowID' => $data['tplt_maskid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tplt_mask', 'RowID' => $data['tplt_maskid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tplt_maskid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplt_mask', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_maskid) as tplt_maskid, B2G(tplt_maskid) as id,B2G(instanceid) as instanceid, TPLT_MASK_BRIEF_F(tplt_maskid , NULL) as  brief,B2G(PNAME) pname, TPLD_PARAM_BRIEF_F(pname, NULL) as pname_grid,phide, case phide  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as phide_grid,colwidth,sequence,B2G(PTYPE) ptype, TPLD_PARAMTYPE_BRIEF_F(ptype, NULL) as ptype_grid,paramformat', 'ViewName' => 'tplt_mask'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_maskid) as tplt_maskid, B2G(tplt_maskid) as id,B2G(instanceid) as instanceid, TPLT_MASK_BRIEF_F(tplt_maskid , NULL) as  brief,B2G(PNAME) pname, TPLD_PARAM_BRIEF_F(pname, NULL) as pname_grid,phide, case phide  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as phide_grid,colwidth,sequence,B2G(PTYPE) ptype, TPLD_PARAMTYPE_BRIEF_F(ptype, NULL) as ptype_grid,paramformat', 'ViewName' => 'tplt_mask', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_maskid) as tplt_maskid, B2G(tplt_maskid) as id,B2G(instanceid) as instanceid, TPLT_MASK_BRIEF_F(tplt_maskid , NULL) as  brief,B2G(PNAME) pname, TPLD_PARAM_BRIEF_F(pname, NULL) as pname_grid,phide, case phide  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as phide_grid,colwidth,sequence,B2G(PTYPE) ptype, TPLD_PARAMTYPE_BRIEF_F(ptype, NULL) as ptype_grid,paramformat', 'ViewName' => 'tplt_mask', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tplt_mask', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>