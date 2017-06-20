<?php
class  M_adrwin extends CI_Model
{
    function getCountry()
    {
        $res = $this->jservice->get(array('Action' => 'GetViewData',
            'ViewName' => 'b2g_addr',
            'Sort' => '[{"property":"name", "direction":"ASC"}]',
            'WhereClause' => 'objecttype=8',
            'FieldList'=>'b2g(b2g_addrid) b2g_addrid, objectid, name, treecode'));
        //$query = $this->db->query('select objectid,name,treecode from B2G_Addr where parentobj =0 or ParentObj is null order by name');
        if (empty($res)) {
            return array('success' => FALSE, 'msg' => 'No data found');
        } else {
            return $res;
        }
    }
	
    function getRegion()
    {
        $res = $this->jservice->get(array('Action' => 'GetViewData',
            'ViewName' => 'b2g_addr',
            'Sort' => '[{"property":"treecode", "direction":"ASC"}]',
            'WhereClause' => "(parentobj =0 or ParentObj is null) and treecode <>'004317'",
            'FieldList'=>'b2g(b2g_addrid) b2g_addrid, objectid, name, treecode'));
        //$query = $this->db->query('select objectid,name,treecode from B2G_Addr where parentobj =0 or ParentObj is null order by name');
        if (empty($res)) {
            return array('success' => FALSE, 'msg' => 'No data found');
        } else {
            return $res;
        }
    }

	
	function getCountryRegion($id)
    {
        $res = $this->jservice->get(array('Action' => 'GetViewData',
            'ViewName' => 'b2g_addr',
            'Sort' => '[{"property":"name", "direction":"ASC"}]',
            'WhereClause' => 'objecttype in(1) AND parentobj = '.$id,
            'FieldList'=>'b2g(b2g_addrid) b2g_addrid, objectid, name, treecode'));
        if (empty($res)) {
            return array('success' => FALSE, 'msg' => 'No data found');
        } else {
            return $res;
        }
    }
	
    function getDistrict($id)
    {
        $res = $this->jservice->get(array('Action' => 'GetViewData',
            'ViewName' => 'b2g_addr',
            'Sort' => '[{"property":"name", "direction":"ASC"}]',
            'WhereClause' => 'objecttype in(2,8,9) AND parentobj = '.$id,
            'FieldList'=>'b2g(b2g_addrid) b2g_addrid,objectid, name, treecode'));
        //$query = $this->db->query('select objectid,name,treecode from B2G_Addr where objecttype in(2,8,9) and parentobj =' . $id . ' order by name');
        if (empty($res)) {
            return array('success' => FALSE, 'msg' => 'No data found');
        } else {
            return $res;
        }
    }

	 function getTown($id)
    {
        $res = $this->jservice->get(array('Action' => 'GetViewData',
            'ViewName' => 'b2g_addr',
            'Sort' => '[{"property":"name", "direction":"ASC"}]',
            'WhereClause' => 'objecttype in(3,7) AND parentobj = '.$id,
            'FieldList'=>'b2g(b2g_addrid) b2g_addrid,objectid, name, treecode'));
        if (empty($res)) {
            return array('success' => FALSE, 'msg' => 'No data found');
        } else {
            return $res;
        }
    }
	
    function getTree($node)
    {

//        if (strlen($node) > 0) {

            //$query = $this->db->query('select objectid, B2G_Addr.name +\' \'+ isnull(B2G_Atom.atomname,\'\')   name ,treecode,objecttype,fullname  from B2G_Addr left join B2G_ATOM on B2G_ATOM.ObjAtomId=B2G_Addr.objectatom where objecttype not in (5,6) and treecode like \'' . $node . '\'+\'______\' ');
  //      } else {
            //$query = $this->db->query('select objectid, B2G_Addr.name +\' \'+ isnull(B2G_Atom.atomname,\'\')   name ,treecode,objecttype,fullname  from B2G_Addr left join B2G_ATOM on B2G_ATOM.ObjAtomId=objectatom where objecttype not in (5,6)  and treecode like \'______\' ');
    //    }
	/*
           $res = $this->jservice->get(array('Action' => 'GetViewData',
            'ViewName' => 'B2G_Addr LEFT JOIN B2G_ATOM ON B2G_ATOM.ObjAtomId=B2G_Addr.objectatom',
            'WhereClause' => 'objecttype not in (5,6) AND treecode like \'' . $node . '______\'',
            'FieldList'=>'b2g(b2g_addrid) b2g_addrid,objectid, CONCAT_WS(\' \', B2G_Addr.name, IFNULL(B2G_Atom.atomname, \'\')) name, treecode, objecttype, fullname'));
		*/	
           $res = $this->jservice->get(array('Action' => 'GetViewData',
            'ViewName' => 'B2G_Addr LEFT JOIN B2G_ATOM ON B2G_ATOM.ObjAtomId=B2G_Addr.objectatom',
            'WhereClause' => 'objecttype = 4 AND treecode like \'' . $node . '______\'',
            'FieldList'=>'b2g(b2g_addrid) b2g_addrid, objectid, CONCAT_WS(\' \', B2G_Addr.name, IFNULL(B2G_Atom.atomname, \'\')) name, treecode, objecttype, fullname'));			
        log_message('error', 'query completed');
        $nodes = array();
        log_message('error', 'rows:'.json_encode($res));
        foreach ($res as $row) {
            $nodes[] = array(
                'text' => $row->name,
                'id' => $row->treecode,
                'fullname' => $row->fullname,
				'name' => $row->name,
                'cls' => ($row->objecttype == 4) ? 'file' : 'folder'
            );
        }
        log_message('error', 'nodes found: '.json_encode($nodes));
        return $nodes;
    }

    function getStreet($node, $findtext)
    {
     
	   if (strlen($findtext) > 0) {
	
		$res = $this->jservice->get(array('Action' => 'GetViewData',
			'Sort' => '[{"property":"T.name", "direction":"ASC"}]',
            'ViewName' => 'B2G_addr T left join B2G_ATOM A on T.ObjectAtom=A.ObjAtomId join B2G_addr F on LENGTH(T.treecode)<=LENGTH(F.treecode) AND F.treecode LIKE CONCAT(T.treecode, "%")',
            'WhereClause' => 'F.objecttype not in(5,6) AND T.objecttype not in(5,6) AND F.name LIKE \'%' . $findtext . '%\' AND T.objecttype not in (5,6) AND T.treecode like \'' . $node . '______\' ',
            'FieldList'=>'b2g(b2g_addrid) b2g_addrid, T.objecttype, T.objectid, CONCAT_WS(\' \', T.name, IFNULL(A.atomname, \'\')) name, T.treecode, T.fullname')
        );
	 }else{
       $res = $this->jservice->get(array('Action' => 'GetViewData',
			'Sort' => '[{"property":"B2G_Addr.name", "direction":"ASC"}]',
            'ViewName' => 'B2G_Addr LEFT JOIN B2G_ATOM ON B2G_ATOM.ObjAtomId=B2G_Addr.objectatom',
            'WhereClause' => 'objecttype = 4 AND treecode like \'' . $node . '______\'',
            'FieldList'=>'b2g(b2g_addrid) b2g_addrid, objectid, CONCAT_WS(\' \', B2G_Addr.name, IFNULL(B2G_Atom.atomname, \'\')) name, treecode, objecttype, fullname'));	
	 }

        if (empty($res)) {
            return array('success' => FALSE, 'msg' => 'No data found');
		} else {
			return $res;
		}
    }
}
?>
