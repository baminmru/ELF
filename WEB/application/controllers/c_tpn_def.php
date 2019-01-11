<?php
	 class C_tpn_def extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPN_DEF.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPN_DEF.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpn_defid' =>  $this->input->get_post('tpn_defid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'addr' =>   $this->input->get_post('addr', TRUE)
                ,'thephone' =>   $this->input->get_post('thephone', TRUE)
                ,'orgunit' =>   $this->input->get_post('orgunit', TRUE)
            );
            $tpn_def = $this->m_tpn_def->setRow($data);
            print json_encode($tpn_def);
    }
    function newRow() {
            log_message('debug', 'TPN_DEF.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpn_defid' =>  $this->input->get_post('tpn_defid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'addr' =>   $this->input->get_post('addr', TRUE)
                ,'thephone' =>   $this->input->get_post('thephone', TRUE)
                ,'orgunit' =>   $this->input->get_post('orgunit', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpn_def= $this->m_tpn_def->newRow($instanceid,$data);
            $return = $tpn_def;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPN_DEF.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpn_def = $this->m_tpn_def->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpn_def
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'addr', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpn_def= $this->m_tpn_def->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpn_def= $this->m_tpn_def->getRows($sort);
                }
            }else{
              $tpn_def= $this->m_tpn_def->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpn_def
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPN_DEF.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'addr', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpn_def= $this->m_tpn_def->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpn_def
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPN_DEF.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'addr', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpn_def= $this->m_tpn_def->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpn_def
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPN_DEF.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpn_defid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpn_def->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tpn_def', 'm_tpn_def');
    }
}
?>