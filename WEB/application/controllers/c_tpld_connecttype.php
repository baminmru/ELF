<?php
	 class C_tpld_connecttype extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLD_CONNECTTYPE.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLD_CONNECTTYPE.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpld_connecttypeid' =>  $this->input->get_post('tpld_connecttypeid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
            );
            $tpld_connecttype = $this->m_tpld_connecttype->setRow($data);
            print json_encode($tpld_connecttype);
    }
    function newRow() {
            log_message('debug', 'TPLD_CONNECTTYPE.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpld_connecttypeid' =>  $this->input->get_post('tpld_connecttypeid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpld_connecttype= $this->m_tpld_connecttype->newRow($instanceid,$data);
            $return = $tpld_connecttype;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLD_CONNECTTYPE.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpld_connecttype = $this->m_tpld_connecttype->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpld_connecttype
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
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpld_connecttype= $this->m_tpld_connecttype->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpld_connecttype= $this->m_tpld_connecttype->getRows($sort);
                }
            }else{
              $tpld_connecttype= $this->m_tpld_connecttype->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_connecttype
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLD_CONNECTTYPE.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpld_connecttype= $this->m_tpld_connecttype->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_connecttype
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
        log_message('debug', 'TPLD_CONNECTTYPE.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpld_connecttype= $this->m_tpld_connecttype->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpld_connecttype
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
        log_message('debug', 'TPLD_CONNECTTYPE.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpld_connecttypeid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpld_connecttype->deleteRow($tempId);
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
        $this->load->model('M_tpld_connecttype', 'm_tpld_connecttype');
    }
}
?>